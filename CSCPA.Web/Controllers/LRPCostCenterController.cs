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
    
    public class LRPCostCenterController : Controller
    {
        private readonly ILRPCostCenterService _LRPCostCenterService;

        public LRPCostCenterController(ILRPCostCenterService LRPCostCenterService)
        {
            _LRPCostCenterService = LRPCostCenterService;
        }
        [Authorize("Permissions.LRPCostCenter.View")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("Lrplm2receiptCodeId"),
                                        new DataColumn("Lrplm2disbursementCodeId") });
            // Get you IEnumerable<T> data  
            var results = await _LRPCostCenterService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name,item.Lrplm2receiptCodeId,item.Lrplm2disbursementCodeId);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPCostCenter_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/LRPCostCenter/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPCostCenterService.GetPage(options));
        }

        [Authorize("Permissions.LRPCostCenter.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPCostCenter/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPCostCenter.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPCostCenter/_AddEdit.cshtml", await _LRPCostCenterService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPCostCenterAddEditModel model)
        {
                var result = await _LRPCostCenterService.Save(model);
                if (result)
                {
                    string returnText = "LRP Cost Center ";
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
        [Authorize("Permissions.LRPCostCenter.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPCostCenterService.Update(key, values);
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
        [Authorize("Permissions.LRPCostCenter.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPCostCenterService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Cost Center " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPCostCenterService.GetLookup(options);
        }
    }
}
