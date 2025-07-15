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
using System.IO;
using ClosedXML.Excel;

namespace CSCPA.Web.Controllers
{
    
    public class LRPCompanyController : Controller
    {
        private readonly ILRPCompanyService _lrpCompanyService;
        private readonly ICountryService _countryService;
        private readonly ICountryStateService _countryStateService;

        public LRPCompanyController(ILRPCompanyService lrpCompanyService, ICountryService countryService, ICountryStateService countryStateService)
        {
            _lrpCompanyService = lrpCompanyService;
            _countryService = countryService;
            _countryStateService = countryStateService;
        }
        [Authorize("Permissions.LRPCompany.View")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[11] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("Description"),
                                        new DataColumn("Code"),
                                        new DataColumn("AddressLineI"),
                                        new DataColumn("AddressLineII"),
                                        new DataColumn("City"),
                                        new DataColumn("Zipcode"),
                                        new DataColumn("CountryId"),
                                        new DataColumn("CountryStateId"),
                                        new DataColumn("ParentLrpcompanyId")});

            // Get you IEnumerable<T> data  
            var results = await _lrpCompanyService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.ObjectUID, item.Name, item.Description,item.Code,item.AddressLineI,item.AddressLineII,item.City,item.Zipcode,item.CountryId,
                    item.CountryStateId,item.ParentLrpcompanyId);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPCompany_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/LRPCompany/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_lrpCompanyService.GetPage(options));
        }
        [Authorize("Permissions.LRPCompany.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPCompany/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPCompany.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/LRPCompany/_AddEdit.cshtml", await _lrpCompanyService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPCompanyAddEditModel model)
        {

            var result = await _lrpCompanyService.Save(model);
            if (result)
            {
                string returnText = "Company ";
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

        [Authorize("Permissions.LRPCompany.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _lrpCompanyService.Update(key, values);
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

        [Authorize("Permissions.LRPCompany.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _lrpCompanyService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Company " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _lrpCompanyService.GetLookup(options);
        }

    }
}