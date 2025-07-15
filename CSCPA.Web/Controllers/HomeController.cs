using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CSCPA.Model;
using Microsoft.Extensions.Configuration;

namespace CSCPA.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveGridState(string jsonInput)
        {
            CSCPA_Web.Program.LrpCompanyGridState = jsonInput;
            return Json(new JsonResponse(ResponseType.Success, "Layout saved"));
        }

        [HttpGet]
        public JsonResult GetGridState(string viewName)
        {
            return Json(new JsonResponse(ResponseType.Success, "Layout saved", CSCPA_Web.Program.LrpCompanyGridState));
        }

        [HttpPost]
        public JsonResult SaveGridStateDepartment(string jsonInput)
        {
            CSCPA_Web.Program.LrpDepartmentGridState = jsonInput;
            return Json(new JsonResponse(ResponseType.Success, "Layout saved"));
        }

        [HttpGet]
        public JsonResult GetGridStateDepartment(string viewName)
        {
            return Json(new JsonResponse(ResponseType.Success, "Layout saved", CSCPA_Web.Program.LrpDepartmentGridState));
        }

        [HttpPost]
        public JsonResult SaveGridStateTimeEntry(string jsonInput)
        {
            CSCPA_Web.Program.LrpTimeEntryGridState = jsonInput;
            return Json(new JsonResponse(ResponseType.Success, "Layout saved"));
        }

        [HttpGet]
        public JsonResult GetGridStateTimeEntry(string viewName)
        {
            return Json(new JsonResponse(ResponseType.Success, "Layout saved", CSCPA_Web.Program.LrpTimeEntryGridState));
        }

    }
}