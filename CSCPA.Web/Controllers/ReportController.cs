using ClosedXML.Excel;
using CSCPA.Core;
using CSCPA.Core.Constant;
using CSCPA.Data;
using CSCPA.Model;
using CSCPA.Service;
using CSCPA.Web.Reports;
using DevExpress.XtraReports.UI;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSCPA.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IBdgreportService _BdgreportService;
        private readonly IBdgreportParameterService _parameterService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ReportController(IBdgreportService BdgreportService, IBdgreportParameterService parameterService,
            AppDbContext context, IWebHostEnvironment environment)
        {
            _BdgreportService = BdgreportService;
            _parameterService = parameterService;
            _environment = environment;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView("/Views/Report/_List.cshtml");
        }

        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            return Json(_BdgreportService.GetPage(options));
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            var parameter = await _parameterService.GetParameters(id);
            if(parameter != null)
                return PartialView("/Views/Report/_ReportParameters.cshtml");
           
            var report = new LrpVendorApplicabilityReport();
            report.Parameters["documentType"].Value = "";
            report.Parameters["vendorVoucher"].Value = "";
            report.Parameters["documentType"].Visible = false;
            report.Parameters["vendorVoucher"].Visible = false;
            return PartialView("/Views/Report/_ReportViewer.cshtml", report);
        }

        [HttpPost]
        public async Task<IActionResult> ParametersList(Guid id)
        {
            return Json(await _parameterService.GetParameters(id));
        }

        [HttpGet]
        public IActionResult ReportView(string reportName, string model)
        {
            var isData = model.Split("$");
            reportName = reportName.Split(".")[0];
            XtraReport xtraReport = new XtraReport();
            var path = Path.Combine(_environment.WebRootPath.Replace("wwwroot", "Reports"));
            xtraReport.LoadLayout(path + "\\" + reportName + ".repx");

            foreach (var item in isData)
            {
                var param = item.Split(":");
                xtraReport.Parameters[param[0]].Value = param[1];
                xtraReport.Parameters[param[0]].Visible = false;
            }
            return PartialView("/Views/Report/_ReportViewer.cshtml", xtraReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(BdgreportAddEditModel model)
        {
            var result = await _BdgreportService.Save(model);
            if (result)
            {
                string returnText = "Bdgreport ";
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

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _BdgreportService.GetLookup(options);
        }
    }
}
