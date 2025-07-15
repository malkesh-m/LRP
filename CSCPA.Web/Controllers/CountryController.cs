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
    public class CountryController : Controller
    {
        private readonly ICountryService _CountryService;

        public CountryController(ICountryService CountryService)
        {
            _CountryService = CountryService;
        }
        [Authorize("Permissions.Country.View")]      // On Contoller level <--------------

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[2] {new DataColumn("Id"),
                                        new DataColumn("Name") });
            // Get you IEnumerable<T> data  
            var results = await _CountryService.GetAll();
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
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_Country_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/Country/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_CountryService.GetPage(options));
        }

        [Authorize("Permissions.Country.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/Country/_AddEdit.cshtml");
        }
        [Authorize("Permissions.Country.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return PartialView("/Views/Country/_AddEdit.cshtml", await _CountryService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(CountryAddEditModel model)
        {
           
                var result = await _CountryService.Save(model);
                if (result)
                {
                    string returnText = "Country ";
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
        [Authorize("Permissions.Country.Edit")]

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _CountryService.Update(key, values);
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
            return await _CountryService.GetLookup(options);
        }

        [Authorize("Permissions.Country.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _CountryService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Country " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}