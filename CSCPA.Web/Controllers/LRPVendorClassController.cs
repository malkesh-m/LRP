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
    
    public class LRPVendorClassController : Controller
    {
        private readonly ILRPVendorClassService _LRPVendorClassService;

        public LRPVendorClassController(ILRPVendorClassService LRPVendorClassService)
        {
            _LRPVendorClassService = LRPVendorClassService;
        }

        [Authorize("Permissions.LRPVendorClass.View")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[2] {new DataColumn("Id"),
                                        new DataColumn("VendorClassNo")});
            // Get you IEnumerable<T> data  
            var results = await _LRPVendorClassService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.VendorClassNo);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPVendorClass_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPVendorClass/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPVendorClassService.GetPage(options));
        }

        [Authorize("Permissions.LRPVendorClass.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPVendorClass/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPVendorClass.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPVendorClass/_AddEdit.cshtml", await _LRPVendorClassService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPVendorClassAddEditModel model)
        {
                var result = await _LRPVendorClassService.Save(model);
                if (result)
                {
                    string returnText = "LRP Vendor Class ";
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

        [Authorize("Permissions.LRPVendorClass.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPVendorClassService.Update(key, values);
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
            return await _LRPVendorClassService.GetLookup(options);
        }

        [Authorize("Permissions.LRPVendorClass.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPVendorClassService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRPVendorClass " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}
