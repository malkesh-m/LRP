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
    public class BdgDepartmentController : Controller
    {
        private readonly IBdgDepartmentService _BdgDepartmentService;

        public BdgDepartmentController(IBdgDepartmentService BdgDepartmentService)
        {
            _BdgDepartmentService = BdgDepartmentService;
        }
        [Authorize("Permissions.BDGDepartment.View")]
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
            var results = await _BdgDepartmentService.GetAll();
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
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_BdgDepartment_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/BdgDepartment/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_BdgDepartmentService.GetPage(options));
        }


        [Authorize("Permissions.BDGDepartment.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/BdgDepartment/_AddEdit.cshtml");
        }
        [Authorize("Permissions.BDGDepartment.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/BdgDepartment/_AddEdit.cshtml", await _BdgDepartmentService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(BdgDepartmentAddEditModel model)
        {
            var result = await _BdgDepartmentService.Save(model);
            if (result)
            {
                string returnText = "Bdg Department ";
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
        [Authorize("Permissions.BDGDepartment.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _BdgDepartmentService.Update(key, values);
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
        [Authorize("Permissions.BDGDepartment.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _BdgDepartmentService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Bdg Department " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _BdgDepartmentService.GetLookup(options);
        }

        [HttpGet]
        public async Task<LoadResult> DropLookup(DataSourceLoadOptions options)
        {
            return await _BdgDepartmentService.GetDropLookup(options);
        }

        [HttpGet]
        public JsonResult JsonLookup()
        {
            return Json(_BdgDepartmentService.GetJsonLookup());
        }
    }
}
