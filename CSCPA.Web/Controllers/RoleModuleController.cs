using ClosedXML.Excel;
using CSCPA.Core;
using CSCPA.Core.Constant;
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
    public class RoleModuleController : Controller
    {
        private readonly IRoleModuleService _RoleModuleService;

        public RoleModuleController(IRoleModuleService RoleModuleService)
        {
            _RoleModuleService = RoleModuleService;
        }

        [Authorize("Permissions.Role_Module.View")]      // On Contoller level <--------------
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
                                        new DataColumn("RoleId"),
                                        new DataColumn("ModuleId")});
            // Get you IEnumerable<T> data  
            var results = await _RoleModuleService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name,item.RoleId,item.ModuleId);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_Role_Module_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/RoleModule/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_RoleModuleService.GetPage(options));
        }
        [Authorize("Permissions.Role_Module.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/RoleModule/_AddEdit.cshtml");
        }
        [Authorize("Permissions.Role_Module.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/RoleModule/_AddEdit.cshtml", await _RoleModuleService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(RoleModuleAddEditModel model)
        {
            var result = await _RoleModuleService.Save(model);
            if (result)
            {
                string returnText = "Role Module ";
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
        [HttpPut]
        [Authorize("Permissions.Role_Module.Edit")]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _RoleModuleService.Update(key, values);
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
        [HttpDelete]
        [Authorize("Permissions.Role_Module.Delete")]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _RoleModuleService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Role Module " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _RoleModuleService.GetLookup(options);
        }
    }
}
