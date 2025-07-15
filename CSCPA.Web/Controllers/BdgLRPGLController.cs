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
    public class BdgLRPGLController : Controller
    {
        private readonly ILRPGLTransactionService _BdgLRPGLService;

        public BdgLRPGLController(ILRPGLTransactionService BdgLRPGLService)
        {
            _BdgLRPGLService = BdgLRPGLService;
        }
        [Authorize("Permissions.BDG_LRPGLTransaction.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/BdgLRPGL/_List.cshtml");
        }
        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            var user = User.Identity.GetUserId();
            return Json(_BdgLRPGLService.GetPage(options, user));
        }
        [Authorize("Permissions.BDG_LRPGLTransaction.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/BdgLRPGL/_AddEdit.cshtml");
        }
        [Authorize("Permissions.BDG_LRPGLTransaction.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var transaction = await _BdgLRPGLService.Get(id);
            return PartialView("/Views/BdgLRPGL/_AddEdit.cshtml", transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPGLTransactionAddEditModel model)
        {

            var result = await _BdgLRPGLService.Save(model);
            if (result)
            {
                string returnText = "Company ";
                if (model.ObjectUid == null)
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

        [Authorize("Permissions.BDG_LRPGLTransaction.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _BdgLRPGLService.Update(key, values);
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

        [Authorize("Permissions.BDG_LRPGLTransaction.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _BdgLRPGLService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Company " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _BdgLRPGLService.GetLookup(options);
        }

    }
}