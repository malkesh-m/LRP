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
    public class BdgcompanyController : Controller
    {
        private readonly IBdgcompanyService _BdgcompanyService;

        public BdgcompanyController(IBdgcompanyService BdgcompanyService)
        {
            _BdgcompanyService = BdgcompanyService;
        }

        [Authorize("Permissions.Bdgcompany.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/Bdgcompany/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_BdgcompanyService.GetPage(options));
        }

        [Authorize("Permissions.Bdgcompany.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/Bdgcompany/_AddEdit.cshtml");
        }
        [Authorize("Permissions.Bdgcompany.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/Bdgcompany/_AddEdit.cshtml", await _BdgcompanyService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(BdgcompanyAddEditModel model)
        {
            var result = await _BdgcompanyService.Save(model);
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

        [Authorize("Permissions.Bdgcompany.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _BdgcompanyService.Update(key, values);
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

        [Authorize("Permissions.Bdgcompany.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _BdgcompanyService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Bdg Report " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _BdgcompanyService.GetLookup(options);
        }
    }
}
