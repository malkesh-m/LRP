using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
