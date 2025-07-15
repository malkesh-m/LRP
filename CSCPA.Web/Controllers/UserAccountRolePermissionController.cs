using CSCPA.Core;
using CSCPA.Model;
using CSCPA.Service;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCPA.Web.Controllers
{
    public class UserAccountRolePermissionController : Controller
    {
        private readonly IUserAccountRolePermissionListService _UserAccountRolePermissionService;

        public UserAccountRolePermissionController(IUserAccountRolePermissionListService UserAccountRolePermissionService)
        {
            _UserAccountRolePermissionService = UserAccountRolePermissionService;
        }

        [Authorize("Permissions.UserAccountRolePermission.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/UserAccountRolePermission/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_UserAccountRolePermissionService.GetPage(options));
        }

        [Authorize("Permissions.UserAccountRolePermission.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/UserAccountRolePermission/_AddEdit.cshtml");
        }
        [Authorize("Permissions.UserAccountRolePermission.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/UserAccountRolePermission/_AddEdit.cshtml", await _UserAccountRolePermissionService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(UserAccountRolePermissionAddEditModel model)
        {
            var result = await _UserAccountRolePermissionService.Save(model);
            if (result)
            {
                string returnText = "User Account Role Permission List ";
                if (model.UserAccountId == null)
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

        [Authorize("Permissions.UserAccountRolePermission.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _UserAccountRolePermissionService.Update(key, values);
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

        [Authorize("Permissions.UserAccountRolePermission.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _UserAccountRolePermissionService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "User Account Role Permission List " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

     /*   [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _UserAccountRolePermissionService.GetLookup(options);
        }*/
    }
}
