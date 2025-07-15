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
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ILRPVendorVoucherApplicabilityService
    {
        Task<IEnumerable<LRPVendorVoucherApplicabilityListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPVendorVoucherApplicabilityAddEditModel> Get(Guid id);
        Task<bool> Save(LRPVendorVoucherApplicabilityAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        LoadResult GetParameters(Guid id, DataSourceLoadOptionsBase options);
    }
    public class LRPVendorVoucherApplicabilityService: BaseService, ILRPVendorVoucherApplicabilityService
    {
        public LRPVendorVoucherApplicabilityService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
            : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPVendorVoucherApplicabilityRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPVendorVoucherApplicabilityListModel
                {
                    ObjectUID = s.ObjectUid,
                    LrpdocumentTypeId = s.LrpdocumentTypeId,
                    Name = s.Name,
                    LrpvendorVoucherId = s.LrpvendorVoucherId,
                    AppliedToDocumentNo = s.AppliedToDocumentNo,
                    AppliedAmount = s.AppliedAmount,
                    VoucherNo = s.VoucherNo,
                    DocumentDate = s.DocumentDate,

                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPVendorVoucherApplicabilityListModel>> GetAll()
        {
            return _mapper.Map<List<LRPVendorVoucherApplicabilityListModel>>(await _uow.LRPVendorVoucherApplicabilityRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPVendorVoucherApplicabilityRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPVendorVoucherApplicabilityRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPVendorVoucherApplicabilityAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPVendorVoucherApplicabilityAddEditModel>(await _uow.LRPVendorVoucherApplicabilityRepository.Get(id));
        }

        public async Task<bool> Save(LRPVendorVoucherApplicabilityAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpvendorVoucherApplicability entity = _mapper.Map<LrpvendorVoucherApplicability>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPVendorVoucherApplicabilityRepository.Add(entity);
            }
            else
            {
                LrpvendorVoucherApplicability entity = await _uow.LRPVendorVoucherApplicabilityRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPVendorVoucherApplicabilityAddEditModel, LrpvendorVoucherApplicability>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPVendorVoucherApplicabilityRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpvendorVoucherApplicability entity = await _uow.LRPVendorVoucherApplicabilityRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPVendorVoucherApplicabilityRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPVendorVoucherApplicabilityRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpvendorVoucherApplicability
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public LoadResult GetParameters(Guid id, DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPVendorVoucherApplicabilityRepository.Query().Where(x => x.LrpvendorVoucherId == id && x.IsDeleted == false)
            .Select(s => new LRPVendorVoucherApplicabilityListModel
            {
                ObjectUID = s.ObjectUid,
                LrpdocumentTypeId = s.LrpdocumentTypeId,
                Name = s.Name,
                LrpvendorVoucherId = s.LrpvendorVoucherId,
                AppliedToDocumentNo = s.AppliedToDocumentNo,
                AppliedAmount = s.AppliedAmount,
                VoucherNo = s.VoucherNo,
                DocumentDate = s.DocumentDate,
            }).ToList();

            return DataSourceLoader.Load(query, options);
        }
    }
}
