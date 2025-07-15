using CSCPA.Service;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSCPA.Web.Controllers
{
    public class PortalController : Controller
    {
        private readonly IPortalService _PortalService;

        public PortalController(IPortalService PortalService)
        {
            _PortalService = PortalService;
        }
        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _PortalService.GetLookup(options);
        }
    }
}
