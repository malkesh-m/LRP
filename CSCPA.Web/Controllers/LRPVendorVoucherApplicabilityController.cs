using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CSCPA.Model;
using System;
using CSCPA.Service;
using System.Threading.Tasks;
using CSCPA.Core;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using CSCPA.Web.Reports;

namespace CSCPA.Web.Controllers
{
    
    public class LRPVendorVoucherApplicabilityController : Controller
    {
        private readonly ILRPVendorVoucherApplicabilityService _LRPVendorVoucherApplicabilityService;

        public LRPVendorVoucherApplicabilityController(ILRPVendorVoucherApplicabilityService LRPVendorVoucherApplicabilityService)
        {
            _LRPVendorVoucherApplicabilityService = LRPVendorVoucherApplicabilityService;
        }

        [Authorize("Permissions.LRPVendor_Voucher_Applicability.View")]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListView(Guid id, DataSourceLoadOptions options)
        {
            return Json(_LRPVendorVoucherApplicabilityService.GetParameters(id, options));
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPVendorVoucherApplicability/_List.cshtml");
        }

        public IActionResult Report(Guid Parameter1,Guid Parameter2)
        {
             var report = new LrpVendorApplicabilityReport();
            report.Parameters["documentType"].Value = Parameter1;
            report.Parameters["vendorVoucher"].Value = Parameter2;
            report.Parameters["documentType"].Visible = false;
            report.Parameters["vendorVoucher"].Visible = false;
            return PartialView("/Views/LRPVendorVoucherApplicability/Report.cshtml",report);
        }

        [HttpGet]
        public IActionResult ReportParameter()
        {
            return PartialView("/Views/LRPVendorVoucherApplicability/_ReportParameter.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPVendorVoucherApplicabilityService.GetPage(options));
        }

        [Authorize("Permissions.LRPVendor_Voucher_Applicability.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPVendorVoucherApplicability/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPVendor_Voucher_Applicability.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPVendorVoucherApplicability/_AddEdit.cshtml", await _LRPVendorVoucherApplicabilityService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPVendorVoucherApplicabilityAddEditModel model)
        {
                var result = await _LRPVendorVoucherApplicabilityService.Save(model);
                if (result)
                {
                    string returnText = "LRPVendorVoucherApplicability ";
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

        [Authorize("Permissions.LRPVendor_Voucher_Applicability.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPVendorVoucherApplicabilityService.Update(key, values);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable to Save");
            }
            return BadRequest("Unable to Save");
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPVendorVoucherApplicabilityService.GetLookup(options);
        }

        [Authorize("Permissions.LRPVendor_Voucher_Applicability.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPVendorVoucherApplicabilityService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRPVendorVoucherApplicability " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}
