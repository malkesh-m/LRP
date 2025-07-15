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
    
    public class LRPVendorVoucherController : Controller
    {
        private readonly ILRPVendorVoucherService _LRPVendorVoucherService;

        public LRPVendorVoucherController(ILRPVendorVoucherService LRPVendorVoucherService)
        {
            _LRPVendorVoucherService = LRPVendorVoucherService;
        }

        [Authorize("Permissions.LRPVendor_Voucher.View")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[11] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("Voided"),
                                        new DataColumn("LrpvendorId"),
                                        new DataColumn("VoucherNo"),
                                        new DataColumn("DocumentAmount"),
                                        new DataColumn("DocumentNo"),
                                        new DataColumn("Pstgdate"),
                                        new DataColumn("InvoiceDate"),
                                        new DataColumn("LrpdocumentTypeId"),
                                        new DataColumn("TrxDescription")});
            // Get you IEnumerable<T> data  
            var results = await _LRPVendorVoucherService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name, item.Voided, item.LrpvendorId,item.VoucherNo, item.DocumentAmount, item.DocumentNo, item.Pstgdate,
                    item.InvoiceDate, item.LrpdocumentTypeId, item.TrxDescription);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPVendor_Voucher_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPVendorVoucher/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPVendorVoucherService.GetPage(options));
        }

        public JsonResult ListView(Guid id, DataSourceLoadOptions options)
        {
            return Json(_LRPVendorVoucherService.GetParameters(id, options));
        }

        [Authorize("Permissions.LRPVendor_Voucher.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPVendorVoucher/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPVendor_Voucher.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPVendorVoucher/_AddEdit.cshtml", await _LRPVendorVoucherService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPVendorVoucherAddEditModel model)
        {
                var result = await _LRPVendorVoucherService.Save(model);
                if (result)
                {
                    string returnText = "LRP Vendor voucher ";
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

        [Authorize("Permissions.LRPVendor_Voucher.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPVendorVoucherService.Update(key, values);
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

        [Authorize("Permissions.LRPVendor_Voucher.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPVendorVoucherService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Vendor voucher " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPVendorVoucherService.GetLookup(options);
        }
        [HttpGet]
        public async Task<JsonResult> Lookup1()
        {
            return Json(await _LRPVendorVoucherService.GetLookup1());
        }
    }
}
