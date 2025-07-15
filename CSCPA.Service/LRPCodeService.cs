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
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ILRPCodeService
    {
        Task<IEnumerable<LRPCodeListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPCodeAddEditModel> Get(Guid id);
        Task<bool> Save(LRPCodeAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPCodeService : BaseService, ILRPCodeService
    {
        public LRPCodeService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
        : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPCodeRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPCodeListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    Description= s.Description
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPCodeListModel>> GetAll()
        {
            return _mapper.Map<List<LRPCodeListModel>>(await _uow.LRPCodeRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPCodeRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPCodeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPCodeAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPCodeAddEditModel>(await _uow.LRPCodeRepository.Get(id));
        }

        public async Task<bool> Save(LRPCodeAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Lrpcode entity = _mapper.Map<Lrpcode>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPCodeRepository.Add(entity);
            }
            else
            {
                Lrpcode entity = await _uow.LRPCodeRepository.Get(model.ObjectUID.Value);
                var createdOn = entity.CreatedOn;
                entity = _mapper.Map<LRPCodeAddEditModel, Lrpcode>(model, entity);
                entity.CreatedOn = createdOn;
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPCodeRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }

            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrpcode entity = await _uow.LRPCodeRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPCodeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPCodeRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Lrpcode
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
