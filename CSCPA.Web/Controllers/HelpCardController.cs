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
    public class HelpCardController : Controller
    {
        private readonly IHelpCardService _HelpCardService;

        public HelpCardController(IHelpCardService HelpCardService)
        {
            _HelpCardService = HelpCardService;
        }
        [Authorize("Permissions.HelpCard.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/HelpCard/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_HelpCardService.GetPage(options));
        }

        [Authorize("Permissions.HelpCard.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/HelpCard/_AddEdit.cshtml");
        }
        [Authorize("Permissions.HelpCard.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/HelpCard/_AddEdit.cshtml", await _HelpCardService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(HelpCardAddEditModel model)
        {
            var result = await _HelpCardService.Save(model);
            if (result)
            {
                string returnText = "Help Card ";
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
        [Authorize("Permissions.HelpCard.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _HelpCardService.Update(key, values);
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
        [Authorize("Permissions.HelpCard.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _HelpCardService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "HelpCard " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _HelpCardService.GetLookup(options);
        }
    }
}
