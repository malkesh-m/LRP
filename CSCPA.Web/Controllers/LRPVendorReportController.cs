using CSCPA.Service;
using Microsoft.AspNetCore.Mvc;

namespace CSCPA.Web.Controllers
{
    public class LRPVendorReportController : Controller
    {
        private readonly ILRPVendorReportService _lrpVendorReportService;
        private readonly ICountryService _countryService;
        private readonly ICountryStateService _countryStateService;
        public LRPVendorReportController(ILRPVendorReportService lRPVendorReportService, ICountryService countryService, ICountryStateService countryStateService)
        {
            _lrpVendorReportService = lRPVendorReportService;
            _countryService = countryService;
            _countryStateService = countryStateService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/LRPVendorReport/_List.cshtml");
        }
    }
}
