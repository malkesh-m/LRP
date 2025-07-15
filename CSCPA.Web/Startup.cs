using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CSCPA.Model.Email.EmailConfiguration;
using CSCPA.Model.FilePath;
using CSCPA.Data;
using CSCPA.Ioc;
using CSCPA.Data.Entities;
using Microsoft.AspNetCore.Http;
using CSCPA.Service;
using CSCPA.Web.Permission;
using CSCPA.Web.Seed;
using DevExpress.AspNetCore.Reporting;
using DevExpress.AspNetCore;
using CSCPA.Web.Services;

namespace CSCPA_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDevExpressControls();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Default"),
                    sqlServerOptionsAction: sqlOption => {
                        sqlOption.EnableRetryOnFailure();
                    }));
            /* services.AddIdentity<UserAccount, Role>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

             services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.LoginPath = "/Account/Login";
                 options.LogoutPath = "/User/Logout";
                 options.AccessDeniedPath = "/User/AccessDenied";
                 options.SlidingExpiration = true;
             });*/

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();


            // Add framework services.
            services.AddControllersWithViews(o =>
            {
                //o.Filters.Add(typeof(ExceptionHandlerAttribute));
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            }).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
                //.AddRazorRuntimeCompilation();

            //for 
            /*var userManager = services.GetRequiredService<UserManager<UserAccount>>();
            var roleManager = services.GetRequiredService<RoleManager<Role>>();*/

            EmailConfiguration emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            FilePathConfiguration filePathConfiguration = Configuration.GetSection("FilePathConfiguration").Get<FilePathConfiguration>();

            IocContainer.ConfigureIOC(services, emailConfig, filePathConfiguration);

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<Seed>();
            services.AddTransient<IFileUploadService, FileUploadService>();

            services.ConfigureReportingServices(configurator => {
                configurator.ConfigureWebDocumentViewer(viewerConfigurator => {
                    viewerConfigurator.UseCachedReportSourceBuilder();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,Seed seed)
        {
            app.UseDevExpressControls();
            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };
            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                //endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapRazorPages();
            });

            seed.SeedAdminUser();
        }
    }
}
