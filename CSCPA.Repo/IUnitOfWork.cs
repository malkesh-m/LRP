using CSCPA.Data;
using CSCPA.Data.Entities;
using System.Threading.Tasks;

namespace CSCPA.Repo
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
        public AppDbContext DbContext { get; }
        GenericRepository<Lrpcompany> LRPCompanyRepository { get; }
        GenericRepository<Lrpdepartment> LRPDepartmentRepository { get; }
        GenericRepository<LrptimeEntry> LRPTimeEntryRepository { get; }
        GenericRepository<Country> CountryRepository { get; }
        GenericRepository<CountryState> CountryStateRepository { get; }
        GenericRepository<Gridlayouts1> GridLayoutRepository { get; }
        GenericRepository<Gridlayout> GridLayoutLoginRepository { get; }
        GenericRepository<Lrpgltransaction> LRPGLTransactionRepository { get; }
        GenericRepository<LrpcostCenter> LRPCostCenterRepository { get; }
        GenericRepository<Lrplm2receiptCode> LRPLM2ReceiptCodeRepository { get; }
        GenericRepository<Lrplm2disbursementCode> LRPLM2DisbursementCodeRepository { get; }
        GenericRepository<Lrpvendor> LRPVendorRepository { get; }
        GenericRepository<LrpemployeeType> LRPEmployeeTypeRepository { get; }
        GenericRepository<LrpvendorClass> LRPVendorClassRepository { get; }
        GenericRepository<LrpvendorMaster> LRPVendorMasterRepository { get; }
        GenericRepository<LrpvoucherStatus> LRPVoucherStatusRepository { get; }
        GenericRepository<LrpvendorVoucher> LRPVendorVoucherRepository { get; }
        GenericRepository<Lrpten99TaxType> LRPTen99TaxTypeRepository { get; }
        GenericRepository<Lrpten99BoxNo> LRPTen99BoxNoRepository { get; }
        GenericRepository<LrpdocumentType> LRPDocumentTypeRepository { get; }
        GenericRepository<LrpvendorVoucherApplicability> LRPVendorVoucherApplicabilityRepository { get; }
        GenericRepository<Lrpcode> LRPCodeRepository { get; }
        GenericRepository<Lrpemployee> LRPEmployeeRepository { get; }
        GenericRepository<LrpemployeeStatus> LRPEmployeeStatusRepository { get; }
        GenericRepository<Lrpreport> LRPReportRepository { get; }
        GenericRepository<Role> RoleRepository { get; }
        GenericRepository<UserAccount> UserAccountRepository { get; }
        GenericRepository<Module> ModuleRepository { get; }
        GenericRepository<Menu> MenuRepository { get; }
        GenericRepository<Localisation> LocalisationRepository { get; }
        GenericRepository<HelpCard> HelpCardRepository { get; }
        GenericRepository<UserAccountRole> UserAccountRoleRepository { get; }
        GenericRepository<UserAccountRolePermissionList> UserAccountRolePermissionListRepository { get; }
        GenericRepository<RoleModule> RoleModuleRepository { get; }
        GenericRepository<UserAccountLrpcompany> UserAccountLrpcompanyRepository { get; }
        GenericRepository<UserAccountBdgdepartment> UserAccountBdgdepartmentRepository { get; }
        GenericRepository<Bdgdepartment> BdgdepartmentRepository { get; }
        GenericRepository<Bdgreport> BdgreportRepository { get; }
        GenericRepository<BdgreportParameter> BdgreportParameterRepository { get; }
        GenericRepository<Bdgcompany> BdgcompanyRepository { get; }
        GenericRepository<BdgreportParameterType> BdgreportParameterTypeRepository { get; }
        GenericRepository<Portal> PortalRepository { get; }
        GenericRepository<BdgbudgetInfoGrid> BdgbudgetInfoRepository { get; }
        GenericRepository<YearSetup> YearSetupRepository { get; }
        GenericRepository<BdgaccountGroup> BdgaccountGroupRepository { get; }

        GenericRepository<BdgreportGroupBdgglaccountMapping> BdgreportGroupBdgglaccountMappingRepository { get; }
        GenericRepository<BdgreportGroupDuplicateMasking> BdgreportGroupDuplicateMaskingRepository { get; }
        GenericRepository<BdgreportGroupBdgreport> BdgreportGroupBdgreportRepository { get; }
        GenericRepository<BdgreportGroupMissingMasking> BdgreportGroupMissingMaskingRepository { get; }

        GenericRepository<BdgreportGroup> BdgreportGroupRepository { get; }
        GenericRepository<BdgaccountGroupSubGroup> BdgaccountGroupSubGroupRepository { get; }
        GenericRepository<BdgaccountGroupSubGroupSubGroup> BdgaccountGroupSubGroupSubGroupRepository { get; }
        GenericRepository<BdgaccountGroupSubGroupSubGroupSubGroup> BdgaccountGroupSubGroupSubGroupSubGroupRepository { get; }
        GenericRepository<YesNo> YesNoRepository { get; }
        GenericRepository<LrpvendorVoucherDistribution> LRPVendorVoucherDistributionRepository { get; }
    }
}