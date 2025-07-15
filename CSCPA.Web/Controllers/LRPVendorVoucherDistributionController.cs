using ClosedXML.Excel;
using CSCPA.Core;
using CSCPA.Model;
using CSCPA.Service;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSCPA.Web.Controllers
{

    public class LRPVendorVoucherDistributionController : Controller
    {
        private readonly ILRPVendorVoucherDistributionService _LRPVendorVoucherDistributionService;

        public LRPVendorVoucherDistributionController(ILRPVendorVoucherDistributionService LRPVendorVoucherDistributionService)
        {
            _LRPVendorVoucherDistributionService = LRPVendorVoucherDistributionService;
        }

        [Authorize("Permissions.LRPVendor_Voucher_Distribution.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPVendorVoucherDistribution/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            var departments = User.Claims.Where(x => x.Type == "Department").Select(x => x.Value).ToList();
            return Json(_LRPVendorVoucherDistributionService.GetPage(options, departments));
        }

        public JsonResult ListView(Guid id, DataSourceLoadOptions options)
        {
            return Json(_LRPVendorVoucherDistributionService.GetParameters(id, options));
        }

        [Authorize("Permissions.LRPVendor_Voucher_Distribution.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPVendorVoucherDistribution/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPVendor_Voucher_Distribution.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPVendorVoucherDistribution/_AddEdit.cshtml", await _LRPVendorVoucherDistributionService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPVendorVoucherDistributionAddEditModel model)
        {
            var result = await _LRPVendorVoucherDistributionService.Save(model);
            if (result)
            {
                string returnText = "LRP Vendor Voucher Distribution ";
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

        [Authorize("Permissions.LRPVendor_Voucher_Distribution.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPVendorVoucherDistributionService.Update(key, values);
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

        [Authorize("Permissions.LRPVendor_Voucher_Distribution.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPVendorVoucherDistributionService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Vendor Voucher Distribution " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPVendorVoucherDistributionService.GetLookup(options);
        }
    }
}
