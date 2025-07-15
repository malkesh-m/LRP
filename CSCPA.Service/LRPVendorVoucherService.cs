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
    public interface ILRPVendorVoucherService
    {
        Task<IEnumerable<LRPVendorVoucherListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPVendorVoucherAddEditModel> Get(Guid id);
        Task<bool> Save(LRPVendorVoucherAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        Task<List<LrpvendorVoucher>> GetLookup1();
        LoadResult GetParameters(Guid id, DataSourceLoadOptionsBase options);
    }
    public class LRPVendorVoucherService : BaseService, ILRPVendorVoucherService
    {
        public LRPVendorVoucherService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPVendorVoucherRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPVendorVoucherListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    Voided = s.Voided,
                    LrpvendorId = s.LrpvendorId,
                    VoucherNo = s.VoucherNo,
                    DocumentAmount = s.DocumentAmount,
                    DocumentNo = s.DocumentNo,
                    Pstgdate = s.Pstgdate,
                    InvoiceDate = s.InvoiceDate,
                    LrpdocumentTypeId = s.LrpdocumentTypeId,
                    TrxDescription = s.TrxDescription,
                    Ten99amnt = s.Ten99amnt,
                    Lrpten99BoxNoId = s.Lrpten99BoxNoId,
                    Lrpten99TaxTypeId = s.Lrpten99TaxTypeId
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPVendorVoucherListModel>> GetAll()
        {
            return _mapper.Map<List<LRPVendorVoucherListModel>>(await _uow.LRPVendorVoucherRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPVendorVoucherRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPVendorVoucherRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPVendorVoucherAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPVendorVoucherAddEditModel>(await _uow.LRPVendorVoucherRepository.Get(id));
        }

        public async Task<bool> Save(LRPVendorVoucherAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpvendorVoucher entity = _mapper.Map<LrpvendorVoucher>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPVendorVoucherRepository.Add(entity);
            }
            else
            {
                LrpvendorVoucher entity = await _uow.LRPVendorVoucherRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPVendorVoucherAddEditModel, LrpvendorVoucher>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPVendorVoucherRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpvendorVoucher entity = await _uow.LRPVendorVoucherRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPVendorVoucherRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPVendorVoucherRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpvendorVoucher
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.VoucherNo
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public async Task<List<LrpvendorVoucher>> GetLookup1()
        {
            var query =await _uow.LRPVendorVoucherRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpvendorVoucher
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.VoucherNo
                }).ToListAsync();
            return query;
        }

        public LoadResult GetParameters(Guid id, DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPVendorVoucherRepository.Query().Where(x => x.LrpvendorId == id && x.IsDeleted == false)
            .Select(s => new LRPVendorVoucherListModel
            {
                ObjectUID = s.ObjectUid,
                Name = s.Name,
                Voided = s.Voided,
                LrpvendorId = s.LrpvendorId,
                VoucherNo = s.VoucherNo,
                DocumentAmount = s.DocumentAmount,
                DocumentNo = s.DocumentNo,
                Pstgdate = s.Pstgdate,
                InvoiceDate = s.InvoiceDate,
                LrpdocumentTypeId = s.LrpdocumentTypeId,
                TrxDescription = s.TrxDescription,
            }).ToList();

            return DataSourceLoader.Load(query, options);
        }
    }
}
