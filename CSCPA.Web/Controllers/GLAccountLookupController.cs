using CSCPA.Service;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSCPA.Web.Controllers
{
    public class GLAccountLookupController : Controller
    {
        private IGLAccountLookupService _lookupService;
        public GLAccountLookupController(IGLAccountLookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet]
        public async Task<LoadResult> LookupReportGroup(DataSourceLoadOptions options)
        {
            return await _lookupService.GetLookupReportGroup(options);
        }
        [HttpGet]
        public async Task<LoadResult> LookupGroup(DataSourceLoadOptions options)
        {
            return await _lookupService.GetLookupGroup(options);
        }
        [HttpGet]
        public async Task<LoadResult> LookupSub(DataSourceLoadOptions options)
        {
            return await _lookupService.GetLookupSub(options);
        }
        [HttpGet]
        public async Task<LoadResult> LookupSubSub(DataSourceLoadOptions options)
        {
            return await _lookupService.GetLookupSubSub(options);
        }
        [HttpGet]
        public async Task<LoadResult> LookupSubSubSub(DataSourceLoadOptions options)
        {
            return await _lookupService.GetLookupSubSubSub(options);
        }
    }
}
