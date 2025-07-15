using CSCPA.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CSCPA.Web.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _environment;
        public FileUploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var path = Path.Combine(_environment.WebRootPath.Replace("wwwroot", "Reports"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileName = "Report" + Guid.NewGuid().ToString();
            fileName = fileName.Replace("-", "");
            var filePath = Path.Combine(path, fileName) + Path.GetExtension(file.FileName);
            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileSteam);
            }

            return fileName;
        }
    }
}
