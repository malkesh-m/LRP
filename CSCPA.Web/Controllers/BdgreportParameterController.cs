using ClosedXML.Excel;
using CSCPA.Core;
using CSCPA.Model;
using CSCPA.Service;
using DevExtreme.AspNet.Data;
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
    public class BdgreportParameterController : Controller
    {
        private readonly IBdgreportParameterService _BdgreportParameterService;

        public BdgreportParameterController(IBdgreportParameterService BdgreportParameterService)
        {
            _BdgreportParameterService = BdgreportParameterService;
        }

        [Authorize("Permissions.BDGReport_Parameter.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/BdgreportParameter/_List.cshtml");
        }

        public JsonResult ListView(Guid id, DataSourceLoadOptions options)
        {
            return Json(_BdgreportParameterService.GetParameters(id,options));
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_BdgreportParameterService.GetPage(options));
        }

        [Authorize("Permissions.BDGReport_Parameter.Create")]
        [HttpGet]
        public IActionResult Add(Guid id)
        {
            return PartialView("/Views/BdgreportParameter/_AddEdit.cshtml", new BdgreportParameterAddEditModel { BdgreportId = id });
        }
        [Authorize("Permissions.BDGReport_Parameter.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/BdgreportParameter/_AddEdit.cshtml", await _BdgreportParameterService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(BdgreportParameterAddEditModel model)
        {
            var result = await _BdgreportParameterService.Save(model);
            if (result)
            {
                string returnText = "Bdg Report Parameter ";
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

        [Authorize("Permissions.BDGReport_Parameter.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _BdgreportParameterService.Update(key, values);
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

        [Authorize("Permissions.BDGReport_Parameter.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _BdgreportParameterService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Bdg Report Parameter " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _BdgreportParameterService.GetLookup(options);
        }

        [HttpGet]
        public object LookupTable(DataSourceLoadOptions options)
        {
            return  DataSourceLoader.Load(_BdgreportParameterService.GetLookupTable(), options);
        }
        [HttpGet]
        public object ParameteData(string tableName,string textName,string valueName)
        {
            return _BdgreportParameterService.ParameterData(tableName,textName,valueName);
        }
    }
}
