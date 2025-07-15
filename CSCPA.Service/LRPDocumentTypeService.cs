using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ILRPDocumentTypeService
    {
        Task<IEnumerable<LRPDocumentTypeListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPDocumentTypeAddEditModel> Get(Guid id);
        Task<bool> Save(LRPDocumentTypeAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        Task<List<LrpdocumentType>> GetLookup1();
    }
    public class LRPDocumentTypeService :  BaseService, ILRPDocumentTypeService
    {
        public LRPDocumentTypeService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
          : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPDocumentTypeRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPDocumentTypeListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    Description = s.Description
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPDocumentTypeListModel>> GetAll()
        {
            return _mapper.Map<List<LRPDocumentTypeListModel>>(await _uow.LRPDocumentTypeRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPDocumentTypeRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPDocumentTypeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPDocumentTypeAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPDocumentTypeAddEditModel>(await _uow.LRPDocumentTypeRepository.Get(id));
        }

        public async Task<bool> Save(LRPDocumentTypeAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpdocumentType entity = _mapper.Map<LrpdocumentType>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPDocumentTypeRepository.Add(entity);
            }
            else
            {
                LrpdocumentType entity = await _uow.LRPDocumentTypeRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPDocumentTypeAddEditModel, LrpdocumentType>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPDocumentTypeRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpdocumentType entity = await _uow.LRPDocumentTypeRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPDocumentTypeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPDocumentTypeRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpdocumentType
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public async Task<List<LrpdocumentType>> GetLookup1()
        {
            var query =await _uow.LRPDocumentTypeRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpdocumentType
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                }).ToListAsync();
            return query;
        }
    }
}
