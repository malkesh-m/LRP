using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using CSCPA.Model.Email.EmailConfiguration;
using CSCPA.Model.FilePath;
using CSCPA.Repo;
using CSCPA.Service;

namespace CSCPA.Ioc
{
    public static class IocContainer
    {
        public static void ConfigureIOC(this IServiceCollection services, EmailConfiguration emailConfig, FilePathConfiguration filePathConfig)
        {
            services.AddTransient<UserResolverService>();
            services.AddSingleton(emailConfig);
            services.AddSingleton(filePathConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISharedService, SharedService>();
            services.AddTransient<ILRPCompanyService, LRPCompanyService>();
            services.AddTransient<ILRPDepartmentService, LRPDepartmentService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICountryStateService, CountryStateService>();
            services.AddTransient<IGridLayoutService, GridLayoutService>();
            services.AddTransient<ILRPGLTransactionService, LRPGLTransactionService>();
            services.AddTransient<ILRPVendorVoucherApplicabilityService, LRPVendorVoucherApplicabilityService>();
            services.AddTransient<ILRPCostCenterService, LRPCostCenterService>();
            services.AddTransient<ILRPLM2ReceiptCodeService, LRPLM2ReceiptCodeService>();
            services.AddTransient<ILRPLM2DisbursementCodeService, LRPLM2DisbursementCodeService>();
            services.AddTransient<ILRPVendorClassService, LRPVendorClassService>();
            services.AddTransient<ILRPVendorService, LRPVendorService>();
            services.AddTransient<ILRPEmployeeTypeService, LRPEmployeeTypeService>();
            services.AddTransient<ILRPVoucherStatusService, LRPVoucherStatusService>();
            services.AddTransient<ILRPVendorMasterService, LRPVendorMasterService>();
            services.AddTransient<ILRPVendorVoucherService, LRPVendorVoucherService>();
            services.AddTransient<ILRPTen99TaxTypeService, LRPTen99TaxTypeService>();
            services.AddTransient<ILRPTen99BoxNoService, LRPTen99BoxNoService>();
            services.AddTransient<ILRPTen99TaxTypeService, LRPTen99TaxTypeService>();
            services.AddTransient<ILRPDocumentTypeService, LRPDocumentTypeService>();
            services.AddTransient<ILRPTimeEntryService, LRPTimeEntryService>();
            services.AddTransient<ILRPCodeService, LRPCodeService>();
            services.AddTransient<ILRPEmployeeService, LRPEmployeeService>();
            services.AddTransient<ILRPEmployeeStatusService, LRPEmployeeStatusService>();
            services.AddTransient<ILRPReportService, LRPReportService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserAccountService, UserAccountService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IUserAccountRolePermissionListService, UserAccountRolePermissionListService>();
            services.AddTransient<IUserAccountRoleService, UserAccountRoleService>();
            services.AddTransient<IRoleModuleService, RoleModuleService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<ILocalisationService, LocalisationService>();
            services.AddTransient<IHelpCardService, HelpCardService>();
            services.AddTransient<IUserAccountLRPCompanyService, UserAccountLRPCompanyService>();
            services.AddTransient<IUserAccountBdgDepartmentService, UserAccountBdgDepartmentService>();
            services.AddTransient<IBdgDepartmentService, BdgDepartmentService>();
            services.AddTransient<IBdgreportParameterService, BdgreportParameterService>();
            services.AddTransient<IBdgreportService, BdgreportService>();
            services.AddTransient<IBdgcompanyService, BdgcompanyService>();
            services.AddTransient<IBdgreportParameterTypeService, BdgreportParameterTypeService>();
            services.AddTransient<IPortalService, PortalService>();
            services.AddTransient<IBdgBudgetService, BdgBudgetService>();
            services.AddTransient<IGLAccountMappingService, GLAccountMappingService>();
            services.AddTransient<IGLAccountLookupService, GLAccountLookupService>();
            services.AddTransient<IMissingMaskingService, MissingMaskingService>();
            services.AddTransient<IDuplicateMaskingService, DuplicateMaskingService>();
            services.AddTransient<IBudgetReportService, BudgetReportService>();
            services.AddTransient<ILRPVendorVoucherDistributionService, LRPVendorVoucherDistributionService>();
        }
    }
}
