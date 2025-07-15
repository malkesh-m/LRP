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
    public class BdgreportParameterTypeController : Controller
    {
        private readonly IBdgreportParameterTypeService _BdgreportParameterTypeService;

        public BdgreportParameterTypeController(IBdgreportParameterTypeService BdgreportParameterTypeService)
        {
            _BdgreportParameterTypeService = BdgreportParameterTypeService;
        }

        [Authorize("Permissions.BDGReportParameterType.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/BdgreportParameterType/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_BdgreportParameterTypeService.GetPage(options));
        }

        [Authorize("Permissions.BDGReportParameterType.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/BdgreportParameterType/_AddEdit.cshtml");
        }
        [Authorize("Permissions.BDGReportParameterType.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/BdgreportParameterType/_AddEdit.cshtml", await _BdgreportParameterTypeService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(BdgreportParameterTypeAddEditModel model)
        {
            var result = await _BdgreportParameterTypeService.Save(model);
            if (result)
            {
                string returnText = "Bdg Report Parameter Type ";
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

        [Authorize("Permissions.BDGReportParameterType.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _BdgreportParameterTypeService.Update(key, values);
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

        [Authorize("Permissions.BDGReportParameterType.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _BdgreportParameterTypeService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Bdg Report Parameter Type " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _BdgreportParameterTypeService.GetLookup(options);
        }
    }
}
