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
    public interface ILRPVendorVoucherDistributionService
    {
        Task<IEnumerable<LRPVendorVoucherDistributionListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPVendorVoucherDistributionAddEditModel> Get(Guid id);
        Task<bool> Save(LRPVendorVoucherDistributionAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options, List<string> departments);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        LoadResult GetParameters(Guid id, DataSourceLoadOptionsBase options);
    }
    public class LRPVendorVoucherDistributionService : BaseService, ILRPVendorVoucherDistributionService
    {
        public LRPVendorVoucherDistributionService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
             : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options, List<string> departments)
        {
            var query = _uow.LRPVendorVoucherDistributionRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPVendorVoucherDistributionListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    AccountDescription = s.AccountDescription,
                    AccountNo = s.AccountNo,
                    CreditAmount = s.CreditAmount,
                    DebitAmount = s.DebitAmount,
                    Description = s.Description,
                    LrpvendorVoucherId = s.LrpvendorVoucherId
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPVendorVoucherDistributionListModel>> GetAll()
        {
            return _mapper.Map<List<LRPVendorVoucherDistributionListModel>>(await _uow.LRPVendorVoucherDistributionRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPVendorVoucherDistributionRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPVendorVoucherDistributionRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPVendorVoucherDistributionAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPVendorVoucherDistributionAddEditModel>(await _uow.LRPVendorVoucherDistributionRepository.Get(id));
        }

        public async Task<bool> Save(LRPVendorVoucherDistributionAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpvendorVoucherDistribution entity = _mapper.Map<LrpvendorVoucherDistribution>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPVendorVoucherDistributionRepository.Add(entity);
            }
            else
            {
                LrpvendorVoucherDistribution entity = await _uow.LRPVendorVoucherDistributionRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPVendorVoucherDistributionAddEditModel, LrpvendorVoucherDistribution>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPVendorVoucherDistributionRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpvendorVoucherDistribution entity = await _uow.LRPVendorVoucherDistributionRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPVendorVoucherDistributionRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPVendorVoucherDistributionRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpvendorVoucherDistribution
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public LoadResult GetParameters(Guid id, DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPVendorVoucherDistributionRepository.Query().Where(x => x.LrpvendorVoucherId == id && x.IsDeleted == false)
            .Select(s => new LRPVendorVoucherDistributionListModel
            {
                ObjectUID = s.ObjectUid,
                Name = s.Name,
                AccountDescription = s.AccountDescription,
                AccountNo = s.AccountNo,
                CreditAmount = s.CreditAmount,
                DebitAmount = s.DebitAmount,
                Description = s.Description,
                LrpvendorVoucherId = s.LrpvendorVoucherId
            }).ToList();

            return DataSourceLoader.Load(query, options);
        }
    }
}
