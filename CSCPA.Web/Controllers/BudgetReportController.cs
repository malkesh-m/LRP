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
    public class BudgetReportController : Controller
    {
        private readonly IBudgetReportService _BudgetReportService;

        public BudgetReportController(IBudgetReportService BudgetReportService)
        {
            _BudgetReportService = BudgetReportService;
        }
        [Authorize("Permissions.BDGReportGroup_BDGReport.View")]      // On Contoller level <--------------

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/BudgetReport/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_BudgetReportService.GetPage(options));
        }

        [Authorize("Permissions.BDGReportGroup_BDGReport.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/BudgetReport/_AddEdit.cshtml");
        }
        [Authorize("Permissions.BDGReportGroup_BDGReport.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/BudgetReport/_AddEdit.cshtml", await _BudgetReportService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(BudgetReportAddEditModel model)
        {

            var result = await _BudgetReportService.Save(model);
            if (result)
            {
                string returnText = "BudgetReport ";
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
        [Authorize("Permissions.BDGReportGroup_BDGReport.Edit")]

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _BudgetReportService.Update(key, values);
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
            return await _BudgetReportService.GetLookup(options);
        }

        [Authorize("Permissions.BDGReportGroup_BDGReport.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _BudgetReportService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "BudgetReport " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}