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
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _UserAccountService;

        public UserAccountController(IUserAccountService UserAccountService)
        {
            _UserAccountService = UserAccountService;
        }

        [Authorize("Permissions.UserAccount.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/UserAccount/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_UserAccountService.GetPage(options));
        }

        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("Email"),
                                        new DataColumn("AddressLineI") });
            // Get you IEnumerable<T> data  
            var results = await _UserAccountService.GetAll();
            foreach(var item in results)
            {
                dt.Rows.Add(item.ObjectUID,item.Name, item.Email, item.AddressLineI);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user+"_username_Grid.xlsx");
                }
            }
        }

        [Authorize("Permissions.UserAccount.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/UserAccount/_AddEdit.cshtml");
        }
      // [Authorize("Permissions.UserAccount.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/UserAccount/_AddEdit.cshtml", await _UserAccountService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(UserAccountAddEditModel model)
        {
            var result = await _UserAccountService.Save(model);
            if (result)
            {
                string returnText = "User Account ";
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

        [Authorize("Permissions.UserAccount.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _UserAccountService.Update(key, values);
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

        [Authorize("Permissions.UserAccount.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _UserAccountService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "User Account" + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _UserAccountService.GetLookup(options);
        }
    }
}
