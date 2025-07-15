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
    
    public class LRPTen99BoxNoController : Controller
    {
        private readonly ILRPTen99BoxNoService _LRPTen99BoxNoService;

        public LRPTen99BoxNoController(ILRPTen99BoxNoService LRPTen99BoxNoService)
        {
            _LRPTen99BoxNoService = LRPTen99BoxNoService;
        }

        [Authorize("Permissions.LRPTen99BoxNo.View")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[6] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("Ten99BoxNo"),
                                        new DataColumn("Ten99BoxText"),
                                        new DataColumn("Dolramnt"),
                                        new DataColumn("Lrpten99TaxTypeId")});
            // Get you IEnumerable<T> data  
            var results = await _LRPTen99BoxNoService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name,item.Ten99BoxNo,item.Ten99BoxText,item.Dolramnt,item.Lrpten99TaxTypeId);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPTen99BoxNo_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPTen99BoxNo/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPTen99BoxNoService.GetPage(options));
        }

        [Authorize("Permissions.LRPTen99BoxNo.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPTen99BoxNo/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPTen99BoxNo.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPTen99BoxNo/_AddEdit.cshtml", await _LRPTen99BoxNoService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPTen99BoxNoAddEditModel model)
        {
                var result = await _LRPTen99BoxNoService.Save(model);
                if (result)
                {
                    string returnText = "LRP Ten99 box no ";
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

        [Authorize("Permissions.LRPTen99BoxNo.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPTen99BoxNoService.Update(key, values);
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
            return await _LRPTen99BoxNoService.GetLookup(options);
        }

        [Authorize("Permissions.LRPTen99BoxNo.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPTen99BoxNoService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Ten99 box no " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}
