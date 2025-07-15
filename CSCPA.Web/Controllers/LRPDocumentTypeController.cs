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
    
    public class LRPDocumentTypeController : Controller
    {
        private readonly ILRPDocumentTypeService _LRPDocumentTypeService;

        public LRPDocumentTypeController(ILRPDocumentTypeService LRPDocumentTypeService)
        {
            _LRPDocumentTypeService = LRPDocumentTypeService;
        }
        [Authorize("Permissions.LRPDocumentType.View")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[3] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("Description")});
            // Get you IEnumerable<T> data  
            var results = await _LRPDocumentTypeService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name, item.Description);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPDocumentType_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/LRPDocumentType/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPDocumentTypeService.GetPage(options));
        }

        [Authorize("Permissions.LRPDocumentType.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPDocumentType/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPDocumentType.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPDocumentType/_AddEdit.cshtml", await _LRPDocumentTypeService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPDocumentTypeAddEditModel model)
        {
                var result = await _LRPDocumentTypeService.Save(model);
                if (result)
                {
                    string returnText = "LRP Document Type ";
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
        [Authorize("Permissions.LRPDocumentType.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPDocumentTypeService.Update(key, values);
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
            return await _LRPDocumentTypeService.GetLookup(options);
        }

        [HttpGet]
        public async Task<JsonResult> Lookup1()
        {
            return Json(await _LRPDocumentTypeService.GetLookup1());
        }

        [Authorize("Permissions.LRPDocumentType.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPDocumentTypeService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Document Type " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}
