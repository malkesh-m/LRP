using CSCPA.Core;
using CSCPA.Model;
using CSCPA.Service;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

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
        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_lrpVendorReportService.GetPage(options));
        }
        [Authorize("Permissions.LRPVendorReport.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPVendorReport/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPVendorReport.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPVendorReport/_AddEdit.cshtml", await _lrpVendorReportService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPVendorReportAddEditModel model)
        {

            var result = await _lrpVendorReportService.Save(model);
            if (result)
            {
                string returnText = "LRP Vendor Report ";
                if (model.ObjectUID == null)
                {
                    returnText += GlobalConstant.Created;
                }
                else
                {
                    returnText += GlobalConstant.Updated;
                }
                return Json(new JsonResponse(ResponseType.Success, returnText));
            }

            return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [Authorize("Permissions.LRPVendorReport.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _lrpVendorReportService.Update(key, values);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable to Save");
            }
        }

        [Authorize("Permissions.LRPVendorReport.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _lrpVendorReportService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Company " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _lrpVendorReportService.GetLookup(options);
        }
    }
}
