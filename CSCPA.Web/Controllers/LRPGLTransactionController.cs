using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
    
    public class LRPGLTransactionController : Controller
    {
        private readonly ILRPGLTransactionService _LRPGLTransactionService;

        public LRPGLTransactionController(ILRPGLTransactionService LRPGLTransactionService)
        {
            _LRPGLTransactionService = LRPGLTransactionService;
        }
        [Authorize("Permissions.LRPGLTransaction.View")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetExcel()
        {
            var user = User.Identity.Name;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[87] {new DataColumn("Id"),
                                        new DataColumn("Name"),
                    new DataColumn("Display"),
                    new DataColumn("LrpcompanyId"),
                    new DataColumn("IdField"),
                    new DataColumn("Classid"),
                    new DataColumn("Acct"),
                    new DataColumn("Descr"),
                    new DataColumn("Batnbr"),
                    new DataColumn("Cpnyid"),
                    new DataColumn("CrtdDatetime"),
                    new DataColumn("CrtdUser"),
                    new DataColumn("Curyid"),
                    new DataColumn("Curyrate"),
                    new DataColumn("Fiscyr"),
                    new DataColumn("IcDistribution"),
                    new DataColumn("Jrnltype"),
                    new DataColumn("Ledgerid"),
                    new DataColumn("Lineid"),
                    new DataColumn("Linenbr"),
                    new DataColumn("Lineref"),
                    new DataColumn("LupdDatetime"),
                    new DataColumn("LupdUser"),
                    new DataColumn("Module"),
                    new DataColumn("Noteid"),
                    new DataColumn("Perent"),
                    new DataColumn("Perpost"),
                    new DataColumn("Posted"),
                    new DataColumn("Refnbr"),
                    new DataColumn("Docnbr"),
                    new DataColumn("Auditnbr"),
                    new DataColumn("Seg1"),
                    new DataColumn("Seg2"),
                    new DataColumn("Seg3"),
                    new DataColumn("Seg4"),
                    new DataColumn("Seg5"),
                    new DataColumn("Seg6"),
                    new DataColumn("Seg7"),
                    new DataColumn("Seg8"),
                    new DataColumn("Seg9"),
                    new DataColumn("Seg10"),
                    new DataColumn("Sub"),
                    new DataColumn("Trandate"),
                    new DataColumn("Trandesc"),
                    new DataColumn("Trantype"),
                    new DataColumn("Lm2Description"),
                    new DataColumn("FinalId"),
                    new DataColumn("Lm2Code"),
                    new DataColumn("EmployeeCode"),
                    new DataColumn("Tstamp"),
                    new DataColumn("Amount"),
                    new DataColumn("Vclassid"),
                    new DataColumn("Masterid"),
                    new DataColumn("Checkdate"),
                    new DataColumn("Checkno"),
                    new DataColumn("Checkdate2"),
                    new DataColumn("Checkno2"),
                    new DataColumn("Checkdate3"),
                    new DataColumn("Checkno3"),
                    new DataColumn("Multiplechecks1"),
                    new DataColumn("Multiplechecks2"),
                    new DataColumn("Userdefined1"),
                    new DataColumn("Userdefined2"),
                    new DataColumn("Lm2Fiscyr"),
                    new DataColumn("EmpFiscyrAcct"),
                    new DataColumn("Lm2FiscyrAcct"),
                    new DataColumn("Lm2FiscyrEmpAcct"),
                    new DataColumn("VendorFiscyrAcct"),
                    new DataColumn("FiscyrAcct"),
                    new DataColumn("CssLink"),
                    new DataColumn("CssLinkLines"),
                    new DataColumn("Description"),
                    new DataColumn("InstallationUid"),
                    new DataColumn("ImportedObjectUid"),
                    new DataColumn("SalesTaxAmount"),
                    new DataColumn("SalesTaxRate"),
                    new DataColumn("SalesTaxYesNoId"),
                    new DataColumn("CalculatedAmount"),
                    new DataColumn("BdgaccountGroup"),
                    new DataColumn("Bdgdepartment"),
                    new DataColumn("BdgaccountGroupSubGroup"),
                    new DataColumn("BdgaccountGroupSubGroupSubGroup"),
                    new DataColumn("BdgaccountGroupSubGroupSubGroupSubGroup"),
                    new DataColumn("GrantNo"),
                    new DataColumn("BdgaccountGroupId"),
                    new DataColumn("BdgdepartmentId2"),
                    new DataColumn("YearSetupId")});
            // Get you IEnumerable<T> data  
            var results = await _LRPGLTransactionService.GetAll();
            foreach (var item in results)
            {
                dt.Rows.Add(item.Id,item.Name, item.Display, item.LrpcompanyId, item.IdField,item.Classid, item.Acct, item.Descr, item.Batnbr, item.Cpnyid,
                    item.CrtdDatetime, item.CrtdUser, item.Curyid, item.Curyrate, item.Fiscyr, item.IcDistribution, item.Jrnltype, item.Ledgerid,  item.Lineid,
                    item.Linenbr,
                    item.Lineref,
                    item.LupdDatetime,
                    item.LupdUser,
                    item.Module,
                    item.Noteid,
                    item.Perent,
                    item.Perpost,
                    item.Posted,
                    item.Refnbr,
                    item.Docnbr,
                    item.Auditnbr,
                    item.Seg1,
                    item.Seg2,
                    item.Seg3,
                    item.Seg4,
                    item.Seg5,
                    item.Seg6,
                    item.Seg7,
                    item.Seg8,
                    item.Seg9,
                    item.Seg10,
                    item.Sub,
                    item.Trandate,
                    item.Trandesc,
                    item.Trantype,
                    item.Lm2Description,
                    item.FinalId,
                    item.Lm2Code,
                    item.EmployeeCode,
                    item.Tstamp,
                    item.Amount,
                    item.Vclassid,
                    item.Masterid,
                    item.Checkdate,
                    item.Checkno,
                    item.Checkdate2,
                    item.Checkno2,
                    item.Checkdate3,
                    item.Checkno3,
                    item.Multiplechecks1,
                    item.Multiplechecks2,
                    item.Userdefined1,
                    item.Userdefined2,
                    item.Lm2Fiscyr,
                    item.EmpFiscyrAcct,
                    item.Lm2FiscyrAcct,
                    item.Lm2FiscyrEmpAcct,
                    item.VendorFiscyrAcct,
                    item.FiscyrAcct,
                    item.CssLink,
                    item.CssLinkLines,
                    item.Description,
                    item.InstallationUid,
                    item.ImportedObjectUid,
                    item.SalesTaxAmount,
                    item.SalesTaxRate,
                    item.SalesTaxYesNoId,
                    item.CalculatedAmount,
                    item.BdgaccountGroup,
                    item.Bdgdepartment,
                    item.BdgaccountGroupSubGroup,
                    item.BdgaccountGroupSubGroupSubGroup,
                    item.BdgaccountGroupSubGroupSubGroupSubGroup,
                    item.GrantNo,
                    item.BdgaccountGroupId,
                    item.BdgdepartmentId2,
                    item.YearSetupId);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", user + "_LRPGLTransaction_Grid.xlsx");
                }
            }
        }
        public PartialViewResult List()
        {
            return PartialView("/Views/LRPGLTransaction/_List.cshtml");
        }

     
        [HttpGet]
        public JsonResult List(DataSourceLoadOptions options)
        {
            var user = User.Identity.GetUserRole();
            var companies = User.Claims.Where(x => x.Type == "Company").Select(x=> x.Value).ToList();
            var departments = User.Claims.Where(x => x.Type == "Department").Select(x => x.Value).ToList();
            return Json(_LRPGLTransactionService.GetPage(options, companies, departments,user));
        }



        [Authorize("Permissions.LRPGLTransaction.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("/Views/LRPGLTransaction/_AddEdit.cshtml");
        }
        [Authorize("Permissions.LRPGLTransaction.Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var transaction = await _LRPGLTransactionService.Get(id);
            return PartialView("/Views/LRPGLTransaction/_AddEdit.cshtml", transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(LRPGLTransactionAddEditModel model)
        {

            var result = await _LRPGLTransactionService.Save(model);
            if (result)
            {
                string returnText = "Company ";
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

        [Authorize("Permissions.LRPGLTransaction.Edit")]
        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            var result = await _LRPGLTransactionService.Update(key, values);
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

        [Authorize("Permissions.LRPGLTransaction.Delete")]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid key)
        {
            var result = await _LRPGLTransactionService.Delete(key);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Company " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _LRPGLTransactionService.GetLookup(options);
        }


        [HttpGet]
        public async Task<LoadResult> LookupSalesTax(DataSourceLoadOptions options)
        {
            return await _LRPGLTransactionService.GetLookupSalesTax(options);
        }
    }
}