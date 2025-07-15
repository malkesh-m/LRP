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
    public class UserAccountRoleController : Controller
    {
        private readonly IUserAccountRoleService _UserAccountRoleService;

        public UserAccountRoleController(IUserAccountRoleService UserAccountRoleService)
        {
            _UserAccountRoleService = UserAccountRoleService;
        }

        [Authorize("Permissions.UserAccount_Role.View")]
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
                                        new DataColumn("UserAccountId"),
                                        new DataColumn("RoleId")});
            // Get you IEnumerable<T> data  
            var results = await _UserAccountRoleService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name, item.UserAccountId, item.RoleId);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_UserAccount_Role_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/UserAccountRole/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_UserAccountRoleService.GetPage(options));
        }

        [Authorize("Permissions.UserAccount_Role.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/UserAccountRole/_AddEdit.cshtml");
        }
        [Authorize("Permissions.UserAccount_Role.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/UserAccountRole/_AddEdit.cshtml", await _UserAccountRoleService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(UserAccountRoleAddEditModel model)
        {
            var result = await _UserAccountRoleService.Save(model);
            if (result)
            {
                string returnText = "User Account Role ";
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

        [Authorize("Permissions.UserAccount_Role.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _UserAccountRoleService.Update(key, values);
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

        [Authorize("Permissions.UserAccount_Role.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _UserAccountRoleService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "User Account Role " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _UserAccountRoleService.GetLookup(options);
        }
    }
}
