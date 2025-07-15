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
    public class LRPLM2DisbursementCodeController : Controller
    {
        private readonly ILRPLM2DisbursementCodeService _LRPLM2DisbursementCodeService;

        public LRPLM2DisbursementCodeController(ILRPLM2DisbursementCodeService LRPLM2DisbursementCodeService)
        {
            _LRPLM2DisbursementCodeService = LRPLM2DisbursementCodeService;
        }

        [Authorize("Permissions.LRPLM2DisbursementCode.View")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[2] {new DataColumn("Id"),
                                        new DataColumn("Name")});
            // Get you IEnumerable<T> data  
            var results = await _LRPLM2DisbursementCodeService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPLM2DisbursementCode_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/LRPLM2DisbursementCode/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_LRPLM2DisbursementCodeService.GetPage(options));
        }


        [Authorize("Permissions.LRPLM2DisbursementCode.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPLM2DisbursementCode/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPLM2DisbursementCode.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPLM2DisbursementCode/_AddEdit.cshtml", await _LRPLM2DisbursementCodeService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPLM2DisbursementCodeAddEditModel model)
        {
                var result = await _LRPLM2DisbursementCodeService.Save(model);
                if (result)
                {
                    string returnText = "LRPLM 2 Disbursement Code ";
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

        [Authorize("Permissions.LRPLM2DisbursementCode.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPLM2DisbursementCodeService.Update(key, values);
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

        [Authorize("Permissions.LRPLM2DisbursementCode.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPLM2DisbursementCodeService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRPLM 2 Disbursement Code " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
        
        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPLM2DisbursementCodeService.GetLookup(options);
        }
    }
}
