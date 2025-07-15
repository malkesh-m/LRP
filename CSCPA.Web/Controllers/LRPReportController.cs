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
    
    public class LRPReportController : Controller
    {
        private readonly ILRPReportService _LRPReportService;

        public LRPReportController(ILRPReportService LRPReportService)
        {
            _LRPReportService = LRPReportService;
        }

        [Authorize("Permissions.LRPReport.View")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[3] {new DataColumn("Id"),
                                        new DataColumn("Name"),new DataColumn("ReportFile")});
            // Get you IEnumerable<T> data  
            var results = await _LRPReportService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name,item.ReportFile);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPReport_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPReport/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPReportService.GetPage(options));
        }

        [Authorize("Permissions.LRPReport.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPReport/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPReport.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPReport/_AddEdit.cshtml", await _LRPReportService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPReportAddEditModel model)
        {
                var result = await _LRPReportService.Save(model);
                if (result)
                {
                    string returnText = "LRP Report ";
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

        [Authorize("Permissions.LRPReport.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPReportService.Update(key, values);
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

        [Authorize("Permissions.LRPReport.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPReportService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Report " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPReportService.GetLookup(options);
        }
    }
}
