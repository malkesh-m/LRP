using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CSCPA_Web
{
    public class Program
    {
        public static string LrpCompanyGridState = string.Empty;
        public static string LrpDepartmentGridState = string.Empty;
        public static string LrpTimeEntryGridState = string.Empty;
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                }).UseWindowsService();
    }
}