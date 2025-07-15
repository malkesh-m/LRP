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
    public class MenuController : Controller
    {
        private readonly IMenuService _MenuService;

        public MenuController(IMenuService MenuService)
        {
            _MenuService = MenuService;
        }

        [Authorize("Permissions.Menu.View")]
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
            var results = await _MenuService.GetAll();
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
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_Menu_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/Menu/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_MenuService.GetPage(options));
        }

        [Authorize("Permissions.Menu.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/Menu/_AddEdit.cshtml");
        }
        [Authorize("Permissions.Menu.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/Menu/_AddEdit.cshtml", await _MenuService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(MenuAddEditModel model)
        {
            var result = await _MenuService.Save(model);
            if (result)
            {
                string returnText = "Menu ";
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

        [Authorize("Permissions.Menu.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _MenuService.Update(key, values);
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

        [Authorize("Permissions.Menu.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _MenuService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Menu " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _MenuService.GetLookup(options);
        }
    }
}
