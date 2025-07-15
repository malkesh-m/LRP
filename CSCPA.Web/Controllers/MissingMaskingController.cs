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
    public class MissingMaskingController : Controller
    {
        private readonly IMissingMaskingService _MissingMaskingService;

        public MissingMaskingController(IMissingMaskingService MissingMaskingService)
        {
            _MissingMaskingService = MissingMaskingService;
        }
        [Authorize("Permissions.BDGReportGroup_MissingMasking.View")]      

        public IActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult List()
        {
            return PartialView("/Views/MissingMasking/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_MissingMaskingService.GetPage(options));
        }

        [Authorize("Permissions.BDGReportGroup_MissingMasking.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/MissingMasking/_AddEdit.cshtml");
        }
        [Authorize("Permissions.BDGReportGroup_MissingMasking.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/MissingMasking/_AddEdit.cshtml", await _MissingMaskingService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(MissingMaskingAddEditModel model)
        {

            var result = await _MissingMaskingService.Save(model);
            if (result)
            {
                string returnText = "MissingMasking ";
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
        [Authorize("Permissions.BDGReportGroup_MissingMasking.Edit")]

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _MissingMaskingService.Update(key, values);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable to Save");
            }
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _MissingMaskingService.GetLookup(options);
        }

        [Authorize("Permissions.BDGReportGroup_MissingMasking.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _MissingMaskingService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "MissingMasking " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}