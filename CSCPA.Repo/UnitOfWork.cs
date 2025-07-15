using CSCPA.Data;
using CSCPA.Data.Entities;
using System;
using System.Threading.Tasks;

namespace CSCPA.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext DbContext { get; set; }
        private GenericRepository<Lrpcompany> _lrpCompanyRepository;
        private GenericRepository<Lrpdepartment> _lrpDepartmentRepository;
        private GenericRepository<LrptimeEntry> _lrpTimeEntryRepository;
        private GenericRepository<Country> _countryRepository;
        private GenericRepository<CountryState> _countryStateRepository;
        private GenericRepository<Gridlayouts1> _gridLayoutRepository;
        private GenericRepository<Gridlayout> _gridLayoutLoginRepository;
        private GenericRepository<Lrpgltransaction> _lrpGlTransactionRepository;
        private GenericRepository<LrpcostCenter> _lrpCostCenterRepository;
        private GenericRepository<Lrplm2disbursementCode> _lrplm2disbursementCodeRepository;
        private GenericRepository<Lrplm2receiptCode> _lrplm2receiptCodeRepository;
        private GenericRepository<Lrpvendor> _lrpvendorRepository;
        private GenericRepository<LrpemployeeType> _lrpemployeeTypeRepository;
        private GenericRepository<LrpvendorClass> _lrpvendorClassRepository;
        private GenericRepository<LrpvoucherStatus> _lrpvoucherStatusRepository;
        private GenericRepository<LrpvendorMaster> _lrpvendorMasterRepository;
        private GenericRepository<LrpvendorVoucher> _lrpvendorVoucherRepository;
        private GenericRepository<Lrpten99BoxNo> _lrpten99BoxNoRepository;
        private GenericRepository<Lrpten99TaxType> _lrpten99TaxTypeRepository;
        private GenericRepository<LrpdocumentType> _lrpdocumentTypeRepository;
        private GenericRepository<LrpvendorVoucherApplicability> _lrpvendorVoucherApplicabilityRepository;
        private GenericRepository<Lrpcode> _lrpcodeRepository;
        private GenericRepository<Lrpemployee> _lrpemployeeRepository;
        private GenericRepository<LrpemployeeStatus> _lrpemployeeStatusRepository;
        private GenericRepository<Lrpreport> _lrpreportRepository;
        private GenericRepository<Role> _roleRepository;
        private GenericRepository<UserAccount> _userAccountRepository;
        private GenericRepository<Module> _moduleRepository;
        private GenericRepository<Menu> _menuRepository;
        private GenericRepository<Localisation> _localisationRepository;
        private GenericRepository<HelpCard> _helpCardRepository;
        private GenericRepository<UserAccountRole> _userAccountRoleRepository;
        private GenericRepository<UserAccountRolePermissionList> _userAccountRolePermissionListRepository;
        private GenericRepository<RoleModule> _roleModuleRepository;
        private GenericRepository<UserAccountLrpcompany> _userAccountLrpcompanyRepository;
        private GenericRepository<UserAccountBdgdepartment> __userAccountBdgdepartmentRepository;
        private GenericRepository<Bdgdepartment> __bdgdepartmentRepository;
        private GenericRepository<Bdgreport> _bdgreportRepository;
        private GenericRepository<BdgreportParameter> _bdgreportParameterRepository;
        private GenericRepository<Bdgcompany> _bdgcompanyRepository;
        private GenericRepository<BdgreportParameterType> _bdgreportParameterTypeRepository;
        private GenericRepository<Portal> _portalRepository;
        private GenericRepository<BdgbudgetInfoGrid> _bdgbudgetInfoRepository;
        private GenericRepository<YearSetup> _yearSetupRepository;
        private GenericRepository<BdgaccountGroup> _bdgaccountGroupRepository;
        private GenericRepository<BdgreportGroupBdgglaccountMapping> _bdgreportGroupBdgglaccountMappingRepository;
        private GenericRepository<BdgreportGroupDuplicateMasking> _bdgreportGroupDuplicateMaskingRepository;
        private GenericRepository<BdgreportGroupBdgreport> _bdgreportGroupBdgreportRepository;
        private GenericRepository<BdgreportGroupMissingMasking> _bdgreportGroupMissingMaskingRepository;
        private GenericRepository<BdgaccountGroupSubGroup> _bdgaccountGroupSubGroupRepository;
        private GenericRepository<BdgaccountGroupSubGroupSubGroup> _bdgaccountGroupSubGroupSubGroupRepository;
        private GenericRepository<BdgaccountGroupSubGroupSubGroupSubGroup> _bdgaccountGroupSubGroupSubGroupSubGroupRepository;
        private GenericRepository<BdgreportGroup> _bdgreportGroupRepository;
        private GenericRepository<YesNo> _yesNoRepository;
        private GenericRepository<LrpvendorVoucherDistribution> _lrpvendorVoucherDistributionRepository;
        public UnitOfWork(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                int _save = await DbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch(Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public GenericRepository<Lrpcompany> LRPCompanyRepository
        {
            get
            {

                if (this._lrpCompanyRepository == null)
                {
                    this._lrpCompanyRepository = new GenericRepository<Lrpcompany>(DbContext);
                }
                return _lrpCompanyRepository;
            }
        }
        public GenericRepository<Lrpdepartment> LRPDepartmentRepository
        {
            get
            {

                if (this._lrpDepartmentRepository == null)
                {
                    this._lrpDepartmentRepository = new GenericRepository<Lrpdepartment>(DbContext);
                }
                return _lrpDepartmentRepository;
            }
        }
        public GenericRepository<LrptimeEntry> LRPTimeEntryRepository
        {
            get
            {

                if (this._lrpTimeEntryRepository == null)
                {
                    this._lrpTimeEntryRepository = new GenericRepository<LrptimeEntry>(DbContext);
                }
                return _lrpTimeEntryRepository;
            }
        }

        public GenericRepository<Country> CountryRepository
        {
            get
            {
                if (this._countryRepository == null)
                {
                    this._countryRepository = new GenericRepository<Country>(DbContext);
                }
                return _countryRepository;
            }
        }

        public GenericRepository<CountryState> CountryStateRepository
        {
            get
            {

                if (this._countryStateRepository == null)
                {
                    this._countryStateRepository = new GenericRepository<CountryState>(DbContext);
                }
                return _countryStateRepository;
            }
        }
        public GenericRepository<Gridlayouts1> GridLayoutRepository
        {
            get
            {

                if (this._gridLayoutRepository == null)
                {
                    this._gridLayoutRepository = new GenericRepository<Gridlayouts1>(DbContext);
                }
                return _gridLayoutRepository;
            }
        }
        public GenericRepository<Gridlayout> GridLayoutLoginRepository
        {
            get
            {

                if (this._gridLayoutLoginRepository == null)
                {
                    this._gridLayoutLoginRepository = new GenericRepository<Gridlayout>(DbContext);
                }
                return _gridLayoutLoginRepository;
            }
        }
        public GenericRepository<Lrpgltransaction> LRPGLTransactionRepository
        {
            get
            {

                if (this._lrpGlTransactionRepository == null)
                {
                    this._lrpGlTransactionRepository = new GenericRepository<Lrpgltransaction>(DbContext);
                }
                return _lrpGlTransactionRepository;
            }
        }
        public GenericRepository<LrpcostCenter> LRPCostCenterRepository
        {
            get
            {

                if (this._lrpCostCenterRepository == null)
                {
                    this._lrpCostCenterRepository = new GenericRepository<LrpcostCenter>(DbContext);
                }
                return _lrpCostCenterRepository;
            }
        }
        public GenericRepository<Lrplm2receiptCode> LRPLM2ReceiptCodeRepository
        {
            get
            {

                if (this._lrplm2receiptCodeRepository == null)
                {
                    this._lrplm2receiptCodeRepository = new GenericRepository<Lrplm2receiptCode>(DbContext);
                }
                return _lrplm2receiptCodeRepository;
            }
        }
        public GenericRepository<Lrplm2disbursementCode> LRPLM2DisbursementCodeRepository
        {
            get
            {

                if (this._lrplm2disbursementCodeRepository == null)
                {
                    this._lrplm2disbursementCodeRepository = new GenericRepository<Lrplm2disbursementCode>(DbContext);
                }
                return _lrplm2disbursementCodeRepository;
            }
        }

        public GenericRepository<LrpemployeeType> LRPEmployeeTypeRepository
        {
            get
            {

                if (this._lrpemployeeTypeRepository == null)
                {
                    this._lrpemployeeTypeRepository = new GenericRepository<LrpemployeeType>(DbContext);
                }
                return _lrpemployeeTypeRepository;
            }
        }

        public GenericRepository<Lrpvendor> LRPVendorRepository
        {
            get
            {

                if (this._lrpvendorRepository == null)
                {
                    this._lrpvendorRepository = new GenericRepository<Lrpvendor>(DbContext);
                }
                return _lrpvendorRepository;
            }
        }
        public GenericRepository<LrpvendorClass> LRPVendorClassRepository
        {
            get
            {

                if (this._lrpvendorClassRepository == null)
                {
                    this._lrpvendorClassRepository = new GenericRepository<LrpvendorClass>(DbContext);
                }
                return _lrpvendorClassRepository;
            }
        }
        public GenericRepository<LrpvendorMaster> LRPVendorMasterRepository
        {
            get
            {

                if (this._lrpvendorMasterRepository == null)
                {
                    this._lrpvendorMasterRepository = new GenericRepository<LrpvendorMaster>(DbContext);
                }
                return _lrpvendorMasterRepository;
            }
        }
        public GenericRepository<LrpvoucherStatus> LRPVoucherStatusRepository
        {
            get
            {

                if (this._lrpvoucherStatusRepository == null)
                {
                    this._lrpvoucherStatusRepository = new GenericRepository<LrpvoucherStatus>(DbContext);
                }
                return _lrpvoucherStatusRepository;
            }
        }
        public GenericRepository<LrpvendorVoucher> LRPVendorVoucherRepository
        {
            get
            {

                if (this._lrpvendorVoucherRepository == null)
                {
                    this._lrpvendorVoucherRepository = new GenericRepository<LrpvendorVoucher>(DbContext);
                }
                return _lrpvendorVoucherRepository;
            }
        }
        public GenericRepository<Lrpten99TaxType> LRPTen99TaxTypeRepository
        {
            get
            {

                if (this._lrpten99TaxTypeRepository == null)
                {
                    this._lrpten99TaxTypeRepository = new GenericRepository<Lrpten99TaxType>(DbContext);
                }
                return _lrpten99TaxTypeRepository;
            }
        }
        public GenericRepository<Lrpten99BoxNo> LRPTen99BoxNoRepository
        {
            get
            {

                if (this._lrpten99BoxNoRepository == null)
                {
                    this._lrpten99BoxNoRepository = new GenericRepository<Lrpten99BoxNo>(DbContext);
                }
                return _lrpten99BoxNoRepository;
            }
        }
        public GenericRepository<LrpdocumentType> LRPDocumentTypeRepository
        {
            get
            {

                if (this._lrpdocumentTypeRepository == null)
                {
                    this._lrpdocumentTypeRepository = new GenericRepository<LrpdocumentType>(DbContext);
                }
                return _lrpdocumentTypeRepository;
            }
        }
        public GenericRepository<LrpvendorVoucherApplicability> LRPVendorVoucherApplicabilityRepository
        {
            get
            {

                if (this._lrpvendorVoucherApplicabilityRepository == null)
                {
                    this._lrpvendorVoucherApplicabilityRepository = new GenericRepository<LrpvendorVoucherApplicability>(DbContext);
                }
                return _lrpvendorVoucherApplicabilityRepository;
            }
        }
        public GenericRepository<Lrpcode> LRPCodeRepository
        {
            get
            {

                if (this._lrpcodeRepository == null)
                {
                    this._lrpcodeRepository = new GenericRepository<Lrpcode>(DbContext);
                }
                return _lrpcodeRepository;
            }
        }
        public GenericRepository<Lrpemployee> LRPEmployeeRepository
        {
            get
            {

                if (this._lrpemployeeRepository == null)
                {
                    this._lrpemployeeRepository = new GenericRepository<Lrpemployee>(DbContext);
                }
                return _lrpemployeeRepository;
            }
        }
        public GenericRepository<LrpemployeeStatus> LRPEmployeeStatusRepository
        {
            get
            {

                if (this._lrpemployeeStatusRepository == null)
                {
                    this._lrpemployeeStatusRepository = new GenericRepository<LrpemployeeStatus>(DbContext);
                }
                return _lrpemployeeStatusRepository;
            }
        }
        public GenericRepository<Lrpreport> LRPReportRepository
        {
            get
            {

                if (this._lrpreportRepository == null)
                {
                    this._lrpreportRepository = new GenericRepository<Lrpreport>(DbContext);
                }
                return _lrpreportRepository;
            }
        }
        public GenericRepository<Role> RoleRepository
        {
            get
            {

                if (this._roleRepository == null)
                {
                    this._roleRepository = new GenericRepository<Role>(DbContext);
                }
                return _roleRepository;
            }
        }
        public GenericRepository<UserAccount> UserAccountRepository
        {
            get
            {

                if (this._userAccountRepository == null)
                {
                    this._userAccountRepository = new GenericRepository<UserAccount>(DbContext);
                }
                return _userAccountRepository;
            }
        }
        public GenericRepository<Module> ModuleRepository
        {
            get
            {

                if (this._moduleRepository == null)
                {
                    this._moduleRepository = new GenericRepository<Module>(DbContext);
                }
                return _moduleRepository;
            }
        }
        public GenericRepository<Menu> MenuRepository
        {
            get
            {

                if (this._menuRepository == null)
                {
                    this._menuRepository = new GenericRepository<Menu>(DbContext);
                }
                return _menuRepository;
            }
        }
        public GenericRepository<Localisation> LocalisationRepository
        {
            get
            {

                if (this._localisationRepository == null)
                {
                    this._localisationRepository = new GenericRepository<Localisation>(DbContext);
                }
                return _localisationRepository;
            }
        }
        public GenericRepository<HelpCard> HelpCardRepository
        {
            get
            {

                if (this._helpCardRepository == null)
                {
                    this._helpCardRepository = new GenericRepository<HelpCard>(DbContext);
                }
                return _helpCardRepository;
            }
        }
        public GenericRepository<UserAccountRole> UserAccountRoleRepository
        {
            get
            {

                if (this._userAccountRoleRepository == null)
                {
                    this._userAccountRoleRepository = new GenericRepository<UserAccountRole>(DbContext);
                }
                return _userAccountRoleRepository;
            }
        }
        public GenericRepository<UserAccountRolePermissionList> UserAccountRolePermissionListRepository
        {
            get
            {

                if (this._userAccountRolePermissionListRepository == null)
                {
                    this._userAccountRolePermissionListRepository = new GenericRepository<UserAccountRolePermissionList>(DbContext);
                }
                return _userAccountRolePermissionListRepository;
            }
        }
        public GenericRepository<RoleModule> RoleModuleRepository
        {
            get
            {

                if (this._roleModuleRepository == null)
                {
                    this._roleModuleRepository = new GenericRepository<RoleModule>(DbContext);
                }
                return _roleModuleRepository;
            }
        }
        public GenericRepository<UserAccountLrpcompany> UserAccountLrpcompanyRepository
        {
            get
            {

                if (this._userAccountLrpcompanyRepository == null)
                {
                    this._userAccountLrpcompanyRepository = new GenericRepository<UserAccountLrpcompany>(DbContext);
                }
                return _userAccountLrpcompanyRepository;
            }
        }
        public GenericRepository<Bdgdepartment> BdgdepartmentRepository
        {
            get
            {

                if (this.__bdgdepartmentRepository == null)
                {
                    this.__bdgdepartmentRepository = new GenericRepository<Bdgdepartment>(DbContext);
                }
                return __bdgdepartmentRepository;
            }
        }
        public GenericRepository<UserAccountBdgdepartment> UserAccountBdgdepartmentRepository
        {
            get
            {

                if (this.__userAccountBdgdepartmentRepository == null)
                {
                    this.__userAccountBdgdepartmentRepository = new GenericRepository<UserAccountBdgdepartment>(DbContext);
                }
                return __userAccountBdgdepartmentRepository;
            }
        }
        public GenericRepository<Bdgreport> BdgreportRepository
        {
            get
            {

                if (this._bdgreportRepository == null)
                {
                    this._bdgreportRepository = new GenericRepository<Bdgreport>(DbContext);
                }
                return _bdgreportRepository;
            }
        }
        public GenericRepository<BdgreportParameter> BdgreportParameterRepository
        {
            get
            {

                if (this._bdgreportParameterRepository == null)
                {
                    this._bdgreportParameterRepository = new GenericRepository<BdgreportParameter>(DbContext);
                }
                return _bdgreportParameterRepository;
            }
        }
        public GenericRepository<BdgreportParameterType> BdgreportParameterTypeRepository
        {
            get
            {

                if (this._bdgreportParameterTypeRepository == null)
                {
                    this._bdgreportParameterTypeRepository = new GenericRepository<BdgreportParameterType>(DbContext);
                }
                return _bdgreportParameterTypeRepository;
            }
        }
        public GenericRepository<Bdgcompany> BdgcompanyRepository
        {
            get
            {

                if (this._bdgcompanyRepository == null)
                {
                    this._bdgcompanyRepository = new GenericRepository<Bdgcompany>(DbContext);
                }
                return _bdgcompanyRepository;
            }
        }
        public GenericRepository<Portal> PortalRepository
        {
            get
            {

                if (this._portalRepository == null)
                {
                    this._portalRepository = new GenericRepository<Portal>(DbContext);
                }
                return _portalRepository;
            }
        }
        public GenericRepository<BdgbudgetInfoGrid> BdgbudgetInfoRepository
        {
            get
            {

                if (this._bdgbudgetInfoRepository == null)
                {
                    this._bdgbudgetInfoRepository = new GenericRepository<BdgbudgetInfoGrid>(DbContext);
                }
                return _bdgbudgetInfoRepository;
            }
        }
        public GenericRepository<YearSetup> YearSetupRepository
        {
            get
            {

                if (this._yearSetupRepository == null)
                {
                    this._yearSetupRepository = new GenericRepository<YearSetup>(DbContext);
                }
                return _yearSetupRepository;
            }
        }
        public GenericRepository<BdgaccountGroup> BdgaccountGroupRepository
        {
            get
            {

                if (this._bdgaccountGroupRepository == null)
                {
                    this._bdgaccountGroupRepository = new GenericRepository<BdgaccountGroup>(DbContext);
                }
                return _bdgaccountGroupRepository;
            }
        }
        public GenericRepository<BdgreportGroupBdgglaccountMapping> BdgreportGroupBdgglaccountMappingRepository
        {
            get
            {

                if (this._bdgreportGroupBdgglaccountMappingRepository == null)
                {
                    this._bdgreportGroupBdgglaccountMappingRepository = new GenericRepository<BdgreportGroupBdgglaccountMapping>(DbContext);
                }
                return _bdgreportGroupBdgglaccountMappingRepository;
            }
        }
        public GenericRepository<BdgreportGroupDuplicateMasking> BdgreportGroupDuplicateMaskingRepository
        {
            get
            {

                if (this._bdgreportGroupDuplicateMaskingRepository == null)
                {
                    this._bdgreportGroupDuplicateMaskingRepository = new GenericRepository<BdgreportGroupDuplicateMasking>(DbContext);
                }
                return _bdgreportGroupDuplicateMaskingRepository;
            }
        }
        public GenericRepository<BdgreportGroupBdgreport> BdgreportGroupBdgreportRepository
        {
            get
            {

                if (this._bdgreportGroupBdgreportRepository == null)
                {
                    this._bdgreportGroupBdgreportRepository = new GenericRepository<BdgreportGroupBdgreport>(DbContext);
                }
                return _bdgreportGroupBdgreportRepository;
            }
        }
        public GenericRepository<BdgreportGroupMissingMasking> BdgreportGroupMissingMaskingRepository
        {
            get
            {

                if (this._bdgreportGroupMissingMaskingRepository == null)
                {
                    this._bdgreportGroupMissingMaskingRepository = new GenericRepository<BdgreportGroupMissingMasking>(DbContext);
                }
                return _bdgreportGroupMissingMaskingRepository;
            }
        }
        public GenericRepository<BdgaccountGroupSubGroup> BdgaccountGroupSubGroupRepository
        {
            get
            {

                if (this._bdgaccountGroupSubGroupRepository == null)
                {
                    this._bdgaccountGroupSubGroupRepository = new GenericRepository<BdgaccountGroupSubGroup>(DbContext);
                }
                return _bdgaccountGroupSubGroupRepository;
            }
        }
        public GenericRepository<BdgaccountGroupSubGroupSubGroup> BdgaccountGroupSubGroupSubGroupRepository
        {
            get
            {

                if (this._bdgaccountGroupSubGroupSubGroupRepository == null)
                {
                    this._bdgaccountGroupSubGroupSubGroupRepository = new GenericRepository<BdgaccountGroupSubGroupSubGroup>(DbContext);
                }
                return _bdgaccountGroupSubGroupSubGroupRepository;
            }
        }
        public GenericRepository<BdgaccountGroupSubGroupSubGroupSubGroup> BdgaccountGroupSubGroupSubGroupSubGroupRepository
        {
            get
            {

                if (this._bdgaccountGroupSubGroupSubGroupSubGroupRepository == null)
                {
                    this._bdgaccountGroupSubGroupSubGroupSubGroupRepository = new GenericRepository<BdgaccountGroupSubGroupSubGroupSubGroup>(DbContext);
                }
                return _bdgaccountGroupSubGroupSubGroupSubGroupRepository;
            }
        }
        public GenericRepository<BdgreportGroup> BdgreportGroupRepository
        {
            get
            {

                if (this._bdgreportGroupRepository == null)
                {
                    this._bdgreportGroupRepository = new GenericRepository<BdgreportGroup>(DbContext);
                }
                return _bdgreportGroupRepository;
            }
        }
        public GenericRepository<YesNo> YesNoRepository
        {
            get
            {

                if (this._yesNoRepository == null)
                {
                    this._yesNoRepository = new GenericRepository<YesNo>(DbContext);
                }
                return _yesNoRepository;
            }
        }
        public GenericRepository<LrpvendorVoucherDistribution> LRPVendorVoucherDistributionRepository
        {
            get
            {

                if (this._lrpvendorVoucherDistributionRepository == null)
                {
                    this._lrpvendorVoucherDistributionRepository = new GenericRepository<LrpvendorVoucherDistribution>(DbContext);
                }
                return _lrpvendorVoucherDistributionRepository;
            }
        }
    }
}
