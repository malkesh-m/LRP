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
    
    public class LRPCodeController : Controller
    {
        private readonly ILRPCodeService _LRPCodeService;

        public LRPCodeController(ILRPCodeService LRPCodeService)
        {
            _LRPCodeService = LRPCodeService;
        }
        [Authorize("Permissions.LRPCode.View")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[3] {new DataColumn("Id"),
                                        new DataColumn("Name"),new DataColumn("Description") });
            // Get you IEnumerable<T> data  
            var results = await _LRPCodeService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name,item.Description);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPCode_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/LRPCode/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPCodeService.GetPage(options));
        }

        [Authorize("Permissions.LRPCode.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPCode/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPCode.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPCode/_AddEdit.cshtml", await _LRPCodeService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPCodeAddEditModel model)
        {
                var result = await _LRPCodeService.Save(model);
                if (result)
                {
                    string returnText = "LRP Code ";
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
        [Authorize("Permissions.LRPCode.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPCodeService.Update(key, values);
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
        [Authorize("Permissions.LRPCode.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPCodeService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Code " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPCodeService.GetLookup(options);
        }
    }
}
