using CSCPA.Core;
using CSCPA.Model;
using CSCPA.Service;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSCPA.Web.Controllers
{
    public class BdgreportController : Controller
    {
        private readonly IBdgreportService _BdgreportService;

        public BdgreportController(IBdgreportService BdgreportService)
        {
            _BdgreportService = BdgreportService;
        }

        [Authorize("Permissions.BDGReport.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/Bdgreport/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_BdgreportService.GetPage(options));
        }

        [Authorize("Permissions.BDGReport.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/Bdgreport/_AddEdit.cshtml");
        }
        [Authorize("Permissions.BDGReport.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/Bdgreport/_AddEdit.cshtml", await _BdgreportService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(BdgreportAddEditModel model)
        {
            var result = await _BdgreportService.Save(model);
            if (result)
            {
                string returnText = "Bdg Report ";
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

        [Authorize("Permissions.BDGReport.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _BdgreportService.Update(key, values);
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

        [Authorize("Permissions.BDGReport.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _BdgreportService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Bdg Report " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _BdgreportService.GetLookup(options);
        }
    }
}
