using CACPA.Web.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;
using CSCPA.Model;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System;
using CSCPA.Service;
using System.Threading.Tasks;
using CSCPA.Core;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace CSCPA.Web.Controllers
{
    
    public class LRPTimeEntryController : Controller
    {
        private readonly ILRPTimeEntryService _lrpTimeEntryService;
     
        public LRPTimeEntryController(ILRPTimeEntryService lrpTimeEntryService)
        {
            _lrpTimeEntryService = lrpTimeEntryService;
        }

        [Authorize("Permissions.LRPTimeEntry.View")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[8] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("LrpcodeId"),
                                        new DataColumn("LrpemployeeId"),
                                        new DataColumn("LrpDateStart"),
                                        new DataColumn("LrpDateEnd"),
                                        new DataColumn("Percentage"),
                                        new DataColumn("Description")});
            // Get you IEnumerable<T> data  
            var results = await _lrpTimeEntryService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUid, item.Name, item.LrpcodeId,item.LrpemployeeId,item.LrpDateStart,item.LrpDateEnd,item.Percentage,item.Description);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPTimeEntry_Grid.xlsx");
                }
            }
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/LRPTimeEntry/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_lrpTimeEntryService.GetPage(options));
        }

        [Authorize("Permissions.LRPTimeEntry.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPTimeEntry/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPTimeEntry.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPTimeEntry/_AddEdit.cshtml", await _lrpTimeEntryService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPTimeEntryAddEditModel model)
        {

            var result = await _lrpTimeEntryService.Save(model);
            if (result)
            {
                string returnText = "TimeEntry ";
                if (model.ObjectUid == null)
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

        [Authorize("Permissions.LRPTimeEntry.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _lrpTimeEntryService.Update(key, values);
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

        [Authorize("Permissions.LRPTimeEntry.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _lrpTimeEntryService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "TimeEntry " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _lrpTimeEntryService.GetLookup(options);
        }

    }
}