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
    public interface ILRPCostCenterService
    {
        Task<IEnumerable<LRPCostCenterListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPCostCenterAddEditModel> Get(Guid id);
        Task<bool> Save(LRPCostCenterAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPCostCenterService :BaseService, ILRPCostCenterService
    {
        public LRPCostCenterService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPCostCenterRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPCostCenterListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    Lrplm2receiptCodeId = s.Lrplm2receiptCodeId,
                    Lrplm2disbursementCodeId = s.Lrplm2disbursementCodeId
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPCostCenterListModel>> GetAll()
        {
            return _mapper.Map<List<LRPCostCenterListModel>>(await _uow.LRPCostCenterRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPCostCenterRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPCostCenterRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPCostCenterAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPCostCenterAddEditModel>(await _uow.LRPCostCenterRepository.Get(id));
        }

        public async Task<bool> Save(LRPCostCenterAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpcostCenter entity = _mapper.Map<LrpcostCenter>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPCostCenterRepository.Add(entity);
            }
            else
            {
                LrpcostCenter entity = await _uow.LRPCostCenterRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPCostCenterAddEditModel, LrpcostCenter>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPCostCenterRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpcostCenter entity = await _uow.LRPCostCenterRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPCostCenterRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPCostCenterRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpcostCenter
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
