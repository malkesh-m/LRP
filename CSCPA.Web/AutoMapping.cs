using AutoMapper;
using CSCPA.Core;
using CSCPA.Data.Entities;
using CSCPA.Model;

namespace CSCPA.Web
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region LRPCompany
            CreateMap<Lrpcompany, LRPCompanyListModel>();
            CreateMap<Lrpcompany, LRPCompanyAddEditModel>();
            CreateMap<LRPCompanyAddEditModel, Lrpcompany>();
            CreateMap<Gridlayouts1, GridLayoutAddEditModel>();
            CreateMap<GridLayoutAddEditModel, Gridlayouts1>();
            #endregion

            #region LRPDepartment
            CreateMap<Lrpdepartment, LRPDepartmentListModel>();
            CreateMap<Lrpdepartment, LRPDepartmentAddEditModel>();
            CreateMap<LRPDepartmentAddEditModel, Lrpdepartment>();
            #endregion

            #region LRPTimeEntry
            CreateMap<LrptimeEntry, LRPTimeEntryListModel>();
            CreateMap<LrptimeEntry, LRPTimeEntryAddEditModel>();
            CreateMap<LRPTimeEntryAddEditModel, LrptimeEntry>();
            #endregion

            #region LRPCostCenter
            CreateMap<LrpcostCenter, LRPCostCenterListModel>();
            CreateMap<LrpcostCenter, LRPCostCenterAddEditModel>();
            CreateMap<LRPCostCenterAddEditModel, LrpcostCenter>();
            #endregion

            #region Country
            CreateMap<Country, CountryListModel>();
            CreateMap<Country, CountryAddEditModel>();
            CreateMap<CountryAddEditModel, Country>();
            #endregion

            #region CountryState
            CreateMap<CountryState, CountryStateListModel>();
            CreateMap<CountryState, CountryStateAddEditModel>();
            CreateMap<CountryStateAddEditModel, CountryState>();
            #endregion

            #region LRPLM2DisbursementCode
            CreateMap<Lrplm2disbursementCode, LRPLM2DisbursementCodeListModel>();
            CreateMap<Lrplm2disbursementCode, LRPLM2DisbursementCodeAddEditModel>();
            CreateMap<LRPLM2DisbursementCodeAddEditModel, Lrplm2disbursementCode>();
            #endregion

            #region LRPLM2ReceiptCode
            CreateMap<Lrplm2receiptCode, LRPLM2ReceiptCodeListModel>();
            CreateMap<Lrplm2receiptCode, LRPLM2ReceiptCodeAddEditModel>();
            CreateMap<LRPLM2ReceiptCodeAddEditModel, Lrplm2receiptCode>();
            #endregion

            #region LRPVendor
            CreateMap<Lrpvendor, LRPVendorAddEditModel>();
            CreateMap<LRPVendorAddEditModel, Lrpvendor>();
            CreateMap<Lrpvendor, LRPVendorListModel>();
            #endregion

            #region LRPEmployeeType
            CreateMap<LrpemployeeType, LRPEmployeeTypeListModel>();
            CreateMap<LrpemployeeType, LRPEmployeeTypeAddEditModel>();
            CreateMap<LRPEmployeeTypeAddEditModel, LrpemployeeType>();
            #endregion

            #region LRPVendorClass
            CreateMap<LrpvendorClass, LRPVendorClassAddEditModel>();
            CreateMap<LRPVendorClassAddEditModel, LrpvendorClass>();
            CreateMap<LrpvendorClass, LRPVendorClassListModel>();
            #endregion

            #region LRPVendorMaster
            CreateMap<LrpvendorMaster, LRPVendorMasterAddEditModel>();
            CreateMap<LRPVendorMasterAddEditModel, LrpvendorMaster>();
            CreateMap<LrpvendorMaster, LRPVendorMasterListModel>();
            #endregion

            #region LRPVoucherStatus
            CreateMap<LrpvoucherStatus, LRPVoucherStatusAddEditModel>();
            CreateMap<LRPVoucherStatusAddEditModel, LrpvoucherStatus>();
            CreateMap<LrpvoucherStatus, LRPVoucherStatusListModel>();
            #endregion

            #region LRPVendorVoucher
            CreateMap<LrpvendorVoucher, LRPVendorVoucherAddEditModel>();
            CreateMap<LRPVendorVoucherAddEditModel, LrpvendorVoucher>();
            CreateMap<LrpvendorVoucher, LRPVendorVoucherListModel>();
            #endregion

            #region LRPVendorVoucherApplicability
            CreateMap<LrpvendorVoucherApplicability, LRPVendorVoucherApplicabilityAddEditModel>();
            CreateMap<LRPVendorVoucherApplicabilityAddEditModel, LrpvendorVoucherApplicability>();
            CreateMap<LrpvendorVoucherApplicability, LRPVendorVoucherApplicabilityListModel>();
            #endregion

            #region LRPCode
            CreateMap<Lrpcode, LRPCodeAddEditModel>();
            CreateMap<LRPCodeAddEditModel, Lrpcode>();
            CreateMap<Lrpcode, LRPCodeListModel>();
            #endregion

            #region LRPTen99BoxNo
            CreateMap<Lrpten99BoxNo, LRPTen99BoxNoAddEditModel>();
            CreateMap<LRPTen99BoxNoAddEditModel, Lrpten99BoxNo>();
            CreateMap<Lrpten99BoxNo, LRPTen99BoxNoListModel>();
            #endregion

            #region LRPTen99TaxType
            CreateMap<Lrpten99TaxType, LRPTen99TaxTypeAddEditModel>();
            CreateMap<LRPTen99TaxTypeAddEditModel, Lrpten99TaxType>();
            CreateMap<Lrpten99TaxType, LRPTen99TaxTypeListModel>();
            #endregion

            #region LRPEmployee
            CreateMap<Lrpemployee, LRPEmployeeListModel>();
            CreateMap<Lrpemployee, LRPEmployeeAddEditModel>();
            CreateMap<LRPEmployeeAddEditModel, Lrpemployee>();
            #endregion

            #region LRPEmployeeStatus
            CreateMap<LrpemployeeStatus, LRPEmployeeStatusListModel>();
            CreateMap<LrpemployeeStatus, LRPEmployeeStatusAddEditModel>();
            CreateMap<LRPEmployeeStatusAddEditModel, LrpemployeeStatus>();
            #endregion

            #region LRPDocumentType
            CreateMap<LrpdocumentType, LRPDocumentTypeListModel>();
            CreateMap<LrpdocumentType, LRPDocumentTypeAddEditModel>();
            CreateMap<LRPDocumentTypeAddEditModel, LrpdocumentType>();
            #endregion

            #region LRPReport
            CreateMap<Lrpreport, LRPReportListModel>();
            CreateMap<Lrpreport, LRPReportAddEditModel>();
            CreateMap<LRPReportAddEditModel, Lrpreport>();
            #endregion

            #region LRPEmployee
            CreateMap<Lrpemployee, LRPEmployeeListModel>();
            CreateMap<LRPEmployeeAddEditModel, Lrpemployee>();
            CreateMap<Lrpemployee, LRPEmployeeListModel>();
            #endregion

            #region LRPTen99TaxType
            CreateMap<Lrpten99TaxType, LRPTen99TaxTypeListModel>();
            CreateMap<Lrpten99TaxType, LRPTen99TaxTypeAddEditModel>();
            CreateMap<LRPTen99TaxTypeAddEditModel, Lrpten99TaxType>();
            CreateMap<Gridlayouts1, GridLayoutAddEditModel>();
            CreateMap<GridLayoutAddEditModel, Gridlayouts1>();
            #endregion

            #region UserAccount
            CreateMap<UserAccount, UserAccountAddEditModel>();
            CreateMap<UserAccountAddEditModel, UserAccount>();
            CreateMap<UserAccount, UserAccountListModel>();
            #endregion

            #region Role
            CreateMap<Role, RoleAddEditModel>();
            CreateMap<RoleAddEditModel, Role>();
            CreateMap<Role, RoleListModel>();
            #endregion

            #region Module
            CreateMap<Module, ModuleAddEditModel>();
            CreateMap<ModuleAddEditModel, Module>();
            CreateMap<Module, ModuleListModel>();
            #endregion

            #region RoleModule
            CreateMap<RoleModule, RoleModuleAddEditModel>();
            CreateMap<RoleModuleAddEditModel, RoleModule>();
            CreateMap<RoleModule, RoleModuleListModel>();
            #endregion

            #region UserAccountRolePermissionList
            CreateMap<UserAccountRolePermissionList, UserAccountRolePermissionAddEditModel>();
            CreateMap<UserAccountRolePermissionAddEditModel, UserAccountRolePermissionList>();
            CreateMap<UserAccountRolePermissionList, UserAccountRolePermissionListModel>();
            #endregion

            #region UserAccountRole
            CreateMap<UserAccountRole, UserAccountRoleAddEditModel>();
            CreateMap<UserAccountRoleAddEditModel, UserAccountRole>();
            CreateMap<UserAccountRole, UserAccountRoleListModel>();
            #endregion

            #region LRPGLTransaction
            CreateMap<Lrpgltransaction, LRPGLTransactionAddEditModel>();
            CreateMap<LRPGLTransactionAddEditModel, Lrpgltransaction>();
            CreateMap<Lrpgltransaction, LRPGLTransactionListModel>();
            #endregion

            #region UserAccountLRPCompany
            CreateMap<UserAccountLrpcompany, UserAccountLRPCompanyAddEditModel>();
            CreateMap<UserAccountLRPCompanyAddEditModel, UserAccountLrpcompany>();
            CreateMap<UserAccountLrpcompany, UserAccountLRPCompanyListModel>();
            #endregion

            #region UserAccountLBdgDepartment
            CreateMap<UserAccountBdgdepartment, UserAccountBdgDepartmentAddEditModel>();
            CreateMap<UserAccountBdgDepartmentAddEditModel, UserAccountBdgdepartment>();
            CreateMap<UserAccountBdgdepartment, UserAccountBdgDepartmentListModel>();
            #endregion

            #region BdgDepartment
            CreateMap<Bdgdepartment, BdgDepartmentAddEditModel>();
            CreateMap<BdgDepartmentAddEditModel, Bdgdepartment>();
            CreateMap<Bdgdepartment, BdgDepartmentListModel>();
            #endregion

            #region Bdgreport
            CreateMap<Bdgreport, BdgreportAddEditModel>().ForMember(s => s.Source, c => c.Ignore());
            CreateMap<BdgreportAddEditModel, Bdgreport>().ForMember(s=>s.Source,c=> c.Ignore());
            CreateMap<Bdgreport, BdgreportListModel>();
            #endregion

            #region BdgreportParameter
            CreateMap<BdgreportParameter, BdgreportParameterAddEditModel>();
            CreateMap<BdgreportParameterAddEditModel, BdgreportParameter>();
            CreateMap<BdgreportParameter, BdgreportParameterListModel>();
            #endregion


            #region BdgBudget
            CreateMap<BdgbudgetInfoGrid, BdgBudgetAddEditModel>();
            CreateMap<BdgBudgetAddEditModel, BdgbudgetInfoGrid>();
            CreateMap<BdgbudgetInfoGrid, BdgBudgetListModel>();
            #endregion

            #region GLAccountMapping
            CreateMap<BdgreportGroupBdgglaccountMapping, GLAccountMappingAddEditModel>();
            CreateMap<GLAccountMappingAddEditModel, BdgreportGroupBdgglaccountMapping>();
            CreateMap<BdgreportGroupBdgglaccountMapping, GLAccountMappingListModel>();
            #endregion


            #region MissingMasking
            CreateMap<BdgreportGroupMissingMasking, MissingMaskingAddEditModel>();
            CreateMap<MissingMaskingAddEditModel, BdgreportGroupMissingMasking>();
            CreateMap<BdgreportGroupMissingMasking, MissingMaskingListModel>();
            #endregion

            #region DuplicateMasking
            CreateMap<BdgreportGroupDuplicateMasking, DuplicateMaskingAddEditModel>();
            CreateMap<DuplicateMaskingAddEditModel, BdgreportGroupDuplicateMasking>();
            CreateMap<BdgreportGroupDuplicateMasking, DuplicateMaskingListModel>();
            #endregion

            #region BudgetReport
            CreateMap<BdgreportGroupBdgreport, BudgetReportAddEditModel>();
            CreateMap<BudgetReportAddEditModel, BdgreportGroupBdgreport>();
            CreateMap<BdgreportGroupBdgreport, BudgetReportListModel>();
            #endregion

            #region LRPVendorVoucherDistribution
            CreateMap<LrpvendorVoucherDistribution, LRPVendorVoucherDistributionAddEditModel>();
            CreateMap<LRPVendorVoucherDistributionAddEditModel, LrpvendorVoucherDistribution>();
            CreateMap<LrpvendorVoucherDistribution, LRPVendorVoucherDistributionListModel>();
            #endregion
        }
    }
}
