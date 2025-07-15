using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ILRPReportService
    {
        Task<IEnumerable<LRPReportListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPReportAddEditModel> Get(Guid id);
        Task<bool> Save(LRPReportAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPReportService : BaseService, ILRPReportService
    {
        public LRPReportService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
          : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPReportRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPReportListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    ReportFile = s.ReportFile
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPReportListModel>> GetAll()
        {
            return _mapper.Map<List<LRPReportListModel>>(await _uow.LRPReportRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPReportRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPReportRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPReportAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPReportAddEditModel>(await _uow.LRPReportRepository.Get(id));
        }

        public async Task<bool> Save(LRPReportAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Lrpreport entity = _mapper.Map<Lrpreport>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPReportRepository.Add(entity);
            }
            else
            {
                Lrpreport entity = await _uow.LRPReportRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPReportAddEditModel, Lrpreport>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPReportRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrpreport entity = await _uow.LRPReportRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPReportRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPReportRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Lrpreport
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
