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
    public class LocalisationController : Controller
    {
        private readonly ILocalisationService _LocalisationService;

        public LocalisationController(ILocalisationService LocalisationService)
        {
            _LocalisationService = LocalisationService;
        }
        [Authorize("Permissions.Localisation.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/Localisation/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LocalisationService.GetPage(options));
        }

        [Authorize("Permissions.Localisation.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/Localisation/_AddEdit.cshtml");
        }
        [Authorize("Permissions.Localisation.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/Localisation/_AddEdit.cshtml", await _LocalisationService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LocalisationAddEditModel model)
        {
            var result = await _LocalisationService.Save(model);
            if (result)
            {
                string returnText = "Localisation ";
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
        [Authorize("Permissions.Localisation.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LocalisationService.Update(key, values);
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
        [Authorize("Permissions.Localisation.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LocalisationService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Localisation " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LocalisationService.GetLookup(options);
        }
    }
}
