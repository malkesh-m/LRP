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
    
    public class LRPVendorMasterController : Controller
    {
        private readonly ILRPVendorMasterService _LRPVendorMasterService;

        public LRPVendorMasterController(ILRPVendorMasterService LRPVendorMasterService)
        {
            _LRPVendorMasterService = LRPVendorMasterService;
        }

        [Authorize("Permissions.LRPVendorMaster.View")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[2] {new DataColumn("Id"),
                                        new DataColumn("Name")});
            // Get you IEnumerable<T> data  
            var results = await _LRPVendorMasterService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPVendorMaster_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPVendorMaster/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPVendorMasterService.GetPage(options));
        }

        [Authorize("Permissions.LRPVendorMaster.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPVendorMaster/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPVendorMaster.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPVendorMaster/_AddEdit.cshtml", await _LRPVendorMasterService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPVendorMasterAddEditModel model)
        {
                var result = await _LRPVendorMasterService.Save(model);
                if (result)
                {
                    string returnText = "LRP Vendor master ";
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

        [Authorize("Permissions.LRPVendorMaster.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPVendorMasterService.Update(key, values);
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

        [Authorize("Permissions.LRPVendorMaster.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPVendorMasterService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Vendor master " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPVendorMasterService.GetLookup(options);
        }
    }
}
