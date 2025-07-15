using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ILRPGLTransactionService
    {
        Task<IEnumerable<LRPGLTransactionListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPGLTransactionAddEditModel> Get(Guid id);
        Task<bool> Save(LRPGLTransactionAddEditModel model);
        Task<bool> Update(Guid id, string values);
        LoadResult GetPage(DataSourceLoadOptionsBase options,List<string> companies,List<string> departments,string user);
        LoadResult GetPage(DataSourceLoadOptionsBase options, string user);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<LoadResult> GetLookupSalesTax(DataSourceLoadOptionsBase loadOptions);
    }

    public class LRPGLTransactionService : BaseService, ILRPGLTransactionService
    {
        public LRPGLTransactionService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
            : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options, List<string> companies, List<string> departments,string user)
        {
            var query = _uow.LRPGLTransactionRepository.Query().IgnoreAutoIncludes().Where(x => x.IsDeleted == false )
                .Select(s => new LRPGLTransactionListModel
                {
                    ObjectUid = s.ObjectUid,
                    Display = s.Display,
                    Name = s.Name,
                    LrpcompanyId = s.LrpcompanyId,
                    IdField = s.IdField,
                    Classid = s.Classid,
                    Acct = s.Acct,
                    Descr = s.Descr,
                    Batnbr = s.Batnbr,
                    Cpnyid = s.Cpnyid,
                    Fiscyr = s.Fiscyr,
                    Id = s.Id,
                    Jrnltype = s.Jrnltype,
                    Ledgerid = s.Ledgerid,
                    Linenbr = s.Linenbr,
                    Lineref = s.Lineref,
                    Module = s.Module,
                    Refnbr = s.Refnbr,
                    Docnbr = s.Docnbr,
                    Auditnbr = s.Auditnbr,
                    Seg1 = s.Seg1,
                    Seg2 = s.Seg2,
                    Seg3 = s.Seg3,
                    Seg4 = s.Seg4,
                    Seg5 = s.Seg5,
                    Seg6 = s.Seg6,
                    Seg7 = s.Seg7,
                    Seg8 = s.Seg8,
                    Seg9 = s.Seg9,
                    Seg10 = s.Seg10,
                    Sub = s.Sub,
                    Trandate = s.Trandate,
                    Trandesc = s.Trandesc,
                    Trantype = s.Trantype,
                    Lm2Description = s.Lm2Description,
                    FinalId = s.FinalId,
                    Lm2Code = s.Lm2Code,
                    EmployeeCode = s.EmployeeCode,
                    Amount = s.Amount,
                    Vclassid = s.Vclassid,
                    Masterid = s.Masterid,
                    Checkdate = s.Checkdate,
                    Checkno = s.Checkno,
                    Checkdate2 = s.Checkdate2,
                    Checkno2 = s.Checkno2,
                    Lm2Fiscyr = s.Lm2Fiscyr,
                    Description = s.Description,
                    SalesTaxAmount = s.SalesTaxAmount,
                    SalesTaxRate = s.SalesTaxRate,
                    SalesTaxYesNoId = s.SalesTaxYesNoId,
                    CalculatedAmount = s.CalculatedAmount,
                    BdgaccountGroup = s.BdgaccountGroup,
                    Bdgdepartment = s.Bdgdepartment,
                    BdgaccountGroupSubGroup = s.BdgaccountGroupSubGroup,
                    BdgaccountGroupSubGroupSubGroup = s.BdgaccountGroupSubGroupSubGroup,
                    BdgaccountGroupSubGroupSubGroupSubGroup = s.BdgaccountGroupSubGroupSubGroupSubGroup,
                    GrantNo = s.GrantNo,
                    BdgdepartmentId2 = s.BdgdepartmentId2,
                });
            if(user != "SystemAdmin")
                query = query.Where(x => companies.Contains(x.LrpcompanyId.ToString()) && departments.Contains(x.BdgdepartmentId2.ToString()));
            return DataSourceLoader.Load(query, options);
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options, string user)
        {
            var query = _uow.LRPGLTransactionRepository.Query().IgnoreAutoIncludes().Where(x => x.IsDeleted == false)
                .Select(s => new LRPGLTransactionListModel
                {
                    ObjectUid = s.ObjectUid,
                    Display = s.Display,
                    Name = s.Name,
                    LrpcompanyId = s.LrpcompanyId,
                    IdField = s.IdField,
                    Classid = s.Classid,
                    Acct = s.Acct,
                    Descr = s.Descr,
                    Batnbr = s.Batnbr,
                    Cpnyid = s.Cpnyid,
                    CrtdDatetime = s.CrtdDatetime,
                    CrtdUser = s.CrtdUser,
                    Curyid = s.Curyid,
                    Curyrate = s.Curyrate,
                    Fiscyr = s.Fiscyr,
                    IcDistribution = s.IcDistribution,
                    Id = s.Id,
                    Jrnltype = s.Jrnltype,
                    Ledgerid = s.Ledgerid,
                    Lineid = s.Lineid,
                    Linenbr = s.Linenbr,
                    Lineref = s.Lineref,
                    LupdDatetime = s.LupdDatetime,
                    LupdUser = s.LupdUser,
                    Module = s.Module,
                    Noteid = s.Noteid,
                    Perent = s.Perent,
                    Perpost = s.Perpost,
                    Posted = s.Posted,
                    Refnbr = s.Refnbr,
                    Docnbr = s.Docnbr,
                    Auditnbr = s.Auditnbr,
                    Seg1 = s.Seg1,
                    Seg2 = s.Seg2,
                    Seg3 = s.Seg3,
                    Seg4 = s.Seg4,
                    Seg5 = s.Seg5,
                    Seg6 = s.Seg6,
                    Seg7 = s.Seg7,
                    Seg8 = s.Seg8,
                    Seg9 = s.Seg9,
                    Seg10 = s.Seg10,
                    Sub = s.Sub,
                    Trandate = s.Trandate,
                    Trandesc = s.Trandesc,
                    Trantype = s.Trantype,
                    Lm2Description = s.Lm2Description,
                    FinalId = s.FinalId,
                    Lm2Code = s.Lm2Code,
                    EmployeeCode = s.EmployeeCode,
                    Tstamp = s.Tstamp,
                    Amount = s.Amount,
                    Vclassid = s.Vclassid,
                    Masterid = s.Masterid,
                    Checkdate = s.Checkdate,
                    Checkno = s.Checkno,
                    Checkdate2 = s.Checkdate2,
                    Checkno2 = s.Checkno2,
                    Checkdate3 = s.Checkdate3,
                    Checkno3 = s.Checkno3,
                    Multiplechecks1 = s.Multiplechecks1,
                    Multiplechecks2 = s.Multiplechecks2,
                    Userdefined1 = s.Userdefined1,
                    Userdefined2 = s.Userdefined2,
                    Lm2Fiscyr = s.Lm2Fiscyr,
                    EmpFiscyrAcct = s.EmpFiscyrAcct,
                    Lm2FiscyrAcct = s.Lm2FiscyrAcct,
                    Lm2FiscyrEmpAcct = s.Lm2FiscyrEmpAcct,
                    VendorFiscyrAcct = s.VendorFiscyrAcct,
                    FiscyrAcct = s.FiscyrAcct,
                    CssLink = s.CssLink,
                    CssLinkLines = s.CssLinkLines,
                    Description = s.Description,
                    InstallationUid = s.InstallationUid,
                    ImportedObjectUid = s.ImportedObjectUid,
                    SalesTaxAmount = s.SalesTaxAmount,
                    SalesTaxRate = s.SalesTaxRate,
                    SalesTaxYesNoId = s.SalesTaxYesNoId,
                    CalculatedAmount = s.CalculatedAmount,
                    BdgaccountGroup = s.BdgaccountGroup,
                    Bdgdepartment = s.Bdgdepartment,
                    BdgaccountGroupSubGroup = s.BdgaccountGroupSubGroup,
                    BdgaccountGroupSubGroupSubGroup = s.BdgaccountGroupSubGroupSubGroup,
                    BdgaccountGroupSubGroupSubGroupSubGroup = s.BdgaccountGroupSubGroupSubGroupSubGroup,
                    GrantNo = s.GrantNo,
                    BdgaccountGroupId = s.BdgaccountGroupId,
                    BdgdepartmentId2 = s.BdgdepartmentId2,
                    YearSetupId = s.YearSetupId
                });
            var departments = _uow.UserAccountBdgdepartmentRepository.Query().Where(x => x.UserAccountId.ToString() == user).Select(m => m.BdgdepartmentId).ToList();
            query = query.Where(x => departments.Contains((Guid)x.BdgdepartmentId2));
            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPGLTransactionListModel>> GetAll()
        {
            return _mapper.Map<List<LRPGLTransactionListModel>>(await _uow.LRPGLTransactionRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPGLTransactionRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPGLTransactionRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPGLTransactionAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPGLTransactionAddEditModel>(await _uow.LRPGLTransactionRepository.Get(id));
        }

        public async Task<bool> Save(LRPGLTransactionAddEditModel model)
        {

            if (model.ObjectUid == null)
            {
                Lrpgltransaction entity = _mapper.Map<Lrpgltransaction>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPGLTransactionRepository.Add(entity);
            }
            else
            {
                Lrpgltransaction entity = await _uow.LRPGLTransactionRepository.Get(model.ObjectUid);
                entity = _mapper.Map<LRPGLTransactionAddEditModel, Lrpgltransaction>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPGLTransactionRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }

        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPGLTransactionRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListItem
                {
                    Value = x.ObjectUid.ToString().ToLower(),
                    Text = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrpgltransaction entity = await _uow.LRPGLTransactionRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPGLTransactionRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookupSalesTax(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.YesNoRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListModel
                {
                    Value = x.ObjectUid,
                    Text = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

    }
}
