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
    public class UserAccountLRPCompanyController : Controller
    {
        private readonly IUserAccountLRPCompanyService _UserAccountLRPCompanyService;

        public UserAccountLRPCompanyController(IUserAccountLRPCompanyService UserAccountLRPCompanyService)
        {
            _UserAccountLRPCompanyService = UserAccountLRPCompanyService;
        }
        [Authorize("Permissions.UserAccount_LRPCompany.View")]
        public IActionResult Index()
        {
            return View();
        }


        public PartialViewResult List()
        {
            return PartialView("/Views/UserAccountLRPCompany/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_UserAccountLRPCompanyService.GetPage(options));
        }


        [Authorize("Permissions.UserAccount_LRPCompany.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/UserAccountLRPCompany/_AddEdit.cshtml");
        }
        [Authorize("Permissions.UserAccount_LRPCompany.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/UserAccountLRPCompany/_AddEdit.cshtml", await _UserAccountLRPCompanyService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(UserAccountLRPCompanyAddEditModel model)
        {
            var result = await _UserAccountLRPCompanyService.Save(model);
            if (result)
            {
                string returnText = "User Account LRP Company ";
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
        [Authorize("Permissions.UserAccount_LRPCompany.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _UserAccountLRPCompanyService.Update(key, values);
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
        [Authorize("Permissions.UserAccountLRPCompany.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _UserAccountLRPCompanyService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "User Account LRP Company " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _UserAccountLRPCompanyService.GetLookup(options);
        }
    }
}
