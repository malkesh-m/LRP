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
    
    public class LRPTen99TaxTypeController : Controller
    {
        private readonly ILRPTen99TaxTypeService _LRPTen99TaxTypeService;

        public LRPTen99TaxTypeController(ILRPTen99TaxTypeService LRPTen99TaxTypeService)
        {
            _LRPTen99TaxTypeService = LRPTen99TaxTypeService;
        }

        [Authorize("Permissions.LRPTen99TaxType.View")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("DescriptionBp"),
                                        new DataColumn("ValueGp")});
            // Get you IEnumerable<T> data  
            var results = await _LRPTen99TaxTypeService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name, item.DescriptionBp, item.ValueGp);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPTen99TaxType_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPTen99TaxType/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPTen99TaxTypeService.GetPage(options));
        }

        [Authorize("Permissions.LRPTen99TaxType.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPTen99TaxType/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPTen99TaxType.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPTen99TaxType/_AddEdit.cshtml", await _LRPTen99TaxTypeService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPTen99TaxTypeAddEditModel model)
        {
                var result = await _LRPTen99TaxTypeService.Save(model);
                if (result)
                {
                    string returnText = "LRP Ten99 tax type ";
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

        [Authorize("Permissions.LRPTen99TaxType.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPTen99TaxTypeService.Update(key, values);
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
            return await _LRPTen99TaxTypeService.GetLookup(options);
        }

        [Authorize("Permissions.LRPTen99TaxType.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPTen99TaxTypeService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Ten99 tax type " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}
