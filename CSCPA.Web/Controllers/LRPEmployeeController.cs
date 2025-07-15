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
    
    public class LRPEmployeeController : Controller
    {
        private readonly ILRPEmployeeService _LRPEmployeeService;

        public LRPEmployeeController(ILRPEmployeeService LRPEmployeeService)
        {
            _LRPEmployeeService = LRPEmployeeService;
        }
        [Authorize("Permissions.LRPEmployee.View")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[9] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        //new DataColumn("Description"),
                    new DataColumn("FirstName"),
                    new DataColumn("MiddleName"),
                    new DataColumn("LastName"),
                    /*new DataColumn("LrpemployeeTypeId"),
                    new DataColumn("LrpemployeeStatusId"),
                    new DataColumn("LrpcostCenterId"),
                    new DataColumn("LrpdepartmentId"),
                    new DataColumn("IsInactive"),
                    new DataColumn("GrantWorker"),*/
                    new DataColumn("HireDate"),
                    new DataColumn("TermDate"),
                    new DataColumn("JobTitle"),
                    new DataColumn("EmployeeNo")});
            // Get you IEnumerable<T> data  
            var results = await _LRPEmployeeService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name,item.FirstName,item.MiddleName,item.LastName,item.HireDate,item.TermDate,item.JobTitle,
                    item.EmployeeNo);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPEmployee_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/LRPEmployee/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            var departments = User.Claims.Where(x => x.Type == "Department").Select(x => x.Value).ToList();
            return Json(_LRPEmployeeService.GetPage(options, departments));
        }

        [Authorize("Permissions.LRPEmployee.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPEmployee/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPEmployee.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPEmployee/_AddEdit.cshtml", await _LRPEmployeeService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPEmployeeAddEditModel model)
        {
                var result = await _LRPEmployeeService.Save(model);
                if (result)
                {
                    string returnText = "LRP Employee ";
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
        [Authorize("Permissions.LRPEmployee.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPEmployeeService.Update(key, values);
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
        [Authorize("Permissions.LRPEmployee.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPEmployeeService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "LRP Employee " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPEmployeeService.GetLookup(options);
        }
    }
}
