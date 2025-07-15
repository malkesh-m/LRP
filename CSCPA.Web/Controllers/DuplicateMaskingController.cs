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

namespace CSCPA.Web.Controllers
{
    public class DuplicateMaskingController : Controller
    {
        private readonly IDuplicateMaskingService _DuplicateMaskingService;

        public DuplicateMaskingController(IDuplicateMaskingService DuplicateMaskingService)
        {
            _DuplicateMaskingService = DuplicateMaskingService;
        }
        [Authorize("Permissions.BDGReportGroup_DuplicateMasking.View")]      // On Contoller level <--------------

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[2] {new DataColumn("Id"),
                                        new DataColumn("Name") });
            // Get you IEnumerable<T> data  
            var results = await _DuplicateMaskingService.GetAll();
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
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_DuplicateMasking_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/DuplicateMasking/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_DuplicateMaskingService.GetPage(options));
        }

        [Authorize("Permissions.BDGReportGroup_DuplicateMasking.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/DuplicateMasking/_AddEdit.cshtml");
        }
        [Authorize("Permissions.BDGReportGroup_DuplicateMasking.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/DuplicateMasking/_AddEdit.cshtml", await _DuplicateMaskingService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(DuplicateMaskingAddEditModel model)
        {

            var result = await _DuplicateMaskingService.Save(model);
            if (result)
            {
                string returnText = "DuplicateMasking ";
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
        [Authorize("Permissions.BDGReportGroup_DuplicateMasking.Edit")]

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _DuplicateMaskingService.Update(key, values);
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
            return await _DuplicateMaskingService.GetLookup(options);
        }

        [Authorize("Permissions.BDGReportGroup_DuplicateMasking.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _DuplicateMaskingService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "DuplicateMasking " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}