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
    
    public class LRPEmployeeStatusController : Controller
    {
        private readonly ILRPEmployeeStatusService _LRPEmployeeStatusService;

        public LRPEmployeeStatusController(ILRPEmployeeStatusService LRPEmployeeStatusService)
        {
            _LRPEmployeeStatusService = LRPEmployeeStatusService;
        }
        [Authorize("Permissions.LRPEmployeeStatus.View")]
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
            var results = await _LRPEmployeeStatusService.GetAll();
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
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPEmployeeStatus_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/LRPEmployeeStatus/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPEmployeeStatusService.GetPage(options));
        }

        [Authorize("Permissions.LRPEmployeeStatus.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPEmployeeStatus/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPEmployeeStatus.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPEmployeeStatus/_AddEdit.cshtml", await _LRPEmployeeStatusService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPEmployeeStatusAddEditModel model)
        {
                var result = await _LRPEmployeeStatusService.Save(model);
                if (result)
                {
                    string returnText = "LRP Employee Status ";
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
        [Authorize("Permissions.LRPEmployeeStatus.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPEmployeeStatusService.Update(key, values);
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
        [Authorize("Permissions.LRPEmployeeStatus.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPEmployeeStatusService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Employee Status " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPEmployeeStatusService.GetLookup(options);
        }
    }
}
