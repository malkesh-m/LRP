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
    
    public class LRPVendorController : Controller
    {
        private readonly ILRPVendorService _LRPVendorService;

        public LRPVendorController(ILRPVendorService LRPVendorService)
        {
            _LRPVendorService = LRPVendorService;
        }

        [Authorize("Permissions.LRPVendor.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPVendor/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            var departments = User.Claims.Where(x => x.Type == "Department").Select(x => x.Value).ToList();
            return Json(_LRPVendorService.GetPage(options,departments));
        }

        [Authorize("Permissions.LRPVendor.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPVendor/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPVendor.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPVendor/_AddEdit.cshtml", await _LRPVendorService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPVendorAddEditModel model)
        {
                var result = await _LRPVendorService.Save(model);
                if (result)
                {
                    string returnText = "LRP Vendor ";
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

        [Authorize("Permissions.LRPVendor.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPVendorService.Update(key, values);
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

        [Authorize("Permissions.LRPVendor.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPVendorService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Vendor " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPVendorService.GetLookup(options);
        }
    }
}
