using CSCPA.Core;
using CSCPA.Model;
using CSCPA.Repo;
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
    public class BdgBudgetController : Controller
    {
        private readonly IBdgBudgetService _BdgBudgetService;
        private readonly IUnitOfWork _uow;

        public BdgBudgetController(IBdgBudgetService BdgBudgetService,IUnitOfWork uow)
        {
            _BdgBudgetService = BdgBudgetService;
            _uow = uow;
        }

        [Authorize("Permissions.BDGBudgetInfo.View")]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/BdgBudget/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_BdgBudgetService.GetPage(options));
        }

        [HttpGet]
        public JsonResult GridList()
        {
            var list = _BdgBudgetService.GetPageList();
            return Json(list);
        }

        [HttpGet]
        public async Task<LoadResult> YearList(DataSourceLoadOptions options)
        {
            return await _BdgBudgetService.GetYearList(options);
        }

        [Authorize("Permissions.BDGBudgetInfo.Create")]
        [HttpGet]
        public IActionResult SelectYearDepartment()
        {
            return PartialView("/Views/BdgBudget/_SelectAdd.cshtml");
        }

        [Authorize("Permissions.BDGBudgetInfo.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/BdgBudget/_AddEdit.cshtml");
        }

        [Authorize("Permissions.BDGBudgetInfo.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/BdgBudget/_AddEdit.cshtml", await _BdgBudgetService.Get(id));
        }

        [HttpPost]
        public JsonResult GetGridData(YearDepartmentModel model)
        {
            var list = new List<BdgBudgetAddEditModel>();
            if (model.Departments != null)
            {
                foreach (var item in model.Departments)
                {
                    list.Add(new BdgBudgetAddEditModel { BdgdepartmentId = item, YearSetupId = model.Year });
                }
            }
            else
                list.Add(new BdgBudgetAddEditModel { YearSetupId = model.Year });
            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(BdgBudgetAddEditModel model)
        {
            var result = await _BdgBudgetService.Save(model);
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

        [HttpPost]
        public async Task<JsonResult> ListAddEdit([FromBody] List<BdgBudgetAddEditModel> model)
        {
            var result = await _BdgBudgetService.BatchSave(model);
            if (result)
            {
                string returnText = "Bdg Report ";
                
                    returnText += GlobalConstant.Created;
                
                return Json(new JsonResponse(ResponseType.Success, returnText));
            }

            return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [Authorize("Permissions.BDGBudgetInfo.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _BdgBudgetService.Update(key, values);
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

        [Authorize("Permissions.BDGBudgetInfo.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _BdgBudgetService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Bdg Report " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _BdgBudgetService.GetLookup(options);
        }
        [HttpGet]
        public async Task<LoadResult> LookupYear(DataSourceLoadOptions options)
        {
            return await _BdgBudgetService.GetLookupYear(options);
        }
    }
}

