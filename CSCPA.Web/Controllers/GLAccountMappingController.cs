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
    public class GLAccountMappingController : Controller
    {
        private readonly IGLAccountMappingService _GLAccountMappingService;

        public GLAccountMappingController(IGLAccountMappingService GLAccountMappingService)
        {
            _GLAccountMappingService = GLAccountMappingService;
        }
        [Authorize("Permissions.BDGReportGroup_BDGGLAccountMapping.View")]      // On Contoller level <--------------

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/GLAccountMapping/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_GLAccountMappingService.GetPage(options));
        }

        [Authorize("Permissions.BDGReportGroup_BDGGLAccountMapping.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/GLAccountMapping/_AddEdit.cshtml");
        }
        [Authorize("Permissions.BDGReportGroup_BDGGLAccountMapping.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/GLAccountMapping/_AddEdit.cshtml", await _GLAccountMappingService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(GLAccountMappingAddEditModel model)
        {

            var result = await _GLAccountMappingService.Save(model);
            if (result)
            {
                string returnText = "GLAccountMapping ";
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
        [Authorize("Permissions.BDGReportGroup_BDGGLAccountMapping.Edit")]

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _GLAccountMappingService.Update(key, values);
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

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _GLAccountMappingService.GetLookup(options);
        }

        [Authorize("Permissions.BDGReportGroup_BDGGLAccountMapping.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _GLAccountMappingService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "GLAccountMapping " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }


    }
}