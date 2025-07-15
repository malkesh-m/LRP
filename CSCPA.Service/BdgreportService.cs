using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface IBdgreportService
    {
        Task<IEnumerable<BdgreportListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<BdgreportAddEditModel> Get(Guid id);
        Task<bool> Save(BdgreportAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class BdgreportService : BaseService, IBdgreportService
    {
        private readonly IFileUploadService _fileUpload;
        public BdgreportService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper, IFileUploadService fileUpload)
          : base(uow, userResolverService, mapper)
        {
            _fileUpload = fileUpload;
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgreportRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new BdgreportListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    ReportFile = s.ReportFile
                }).ToList();
            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<BdgreportListModel>> GetAll()
        {
            return _mapper.Map<List<BdgreportListModel>>(await _uow.BdgreportRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgreportRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.BdgreportRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<BdgreportAddEditModel> Get(Guid id)
        {
            return _mapper.Map<BdgreportAddEditModel>(await _uow.BdgreportRepository.Get(id));
        }

        public async Task<bool> Save(BdgreportAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Bdgreport entity = _mapper.Map<Bdgreport>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                if(model.Source != null)
                    entity.Source = await _fileUpload.UploadFile(model.Source);
                await _uow.BdgreportRepository.Add(entity);
            }
            else
            {
                Bdgreport entity = await _uow.BdgreportRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<BdgreportAddEditModel, Bdgreport>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                if (model.Source != null)
                {
                    entity.Source = await _fileUpload.UploadFile(model.Source);
                }
                await _uow.BdgreportRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Bdgreport entity = await _uow.BdgreportRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.BdgreportRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgreportRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Bdgreport
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        
    }
}
