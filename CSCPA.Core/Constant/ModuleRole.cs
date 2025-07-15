using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Core.Constant
{
    public class ModuleRole
    {
        public static List<string> IsModuleExist()
        {
            return new List<string>()
            {
                $"Country",
                $"Country_State",
                $"HelpCard",
                $"Localisation",
                $"LRPCode",
                $"LRPCompany",
                $"LRPCostCenter",
                $"LRPDepartment",
                $"LRPDocumentType",
                $"LRPEmployee",
                $"LRPEmployeeStatus",
                $"LRPEmployeeType",
                $"LRPGLTransaction",
                $"LRPLM2DisbursementCode",
                $"LRPReport",
                $"LRPLM2ReceiptCode",
                $"LRPTen99BoxNo",
                $"LRPTen99TaxType",
                $"LRPTimeEntry",
                $"LRPVendorClass",
                $"LRPVendor",
                $"LRPVendorMaster",
                $"LRPVendor_Voucher_Applicability",
                $"LRPVendor_Voucher",
                $"LRPVoucherStatus",
                $"Menu",
                $"Module",
                $"Role",
                $"Role_Module",
                $"UserAccount",
                $"UserAccount_Role",
                $"UserAccount_BDGDepartment",
                $"UserAccount_LRPCompany",
                $"BDGCompany",
                $"BDGDepartment",
                $"BDGReport",
                $"BDGReport_Parameter",
                $"BDGReportParameterType",
                $"BDGReportGroup_DuplicateMasking",
                $"BDGReportGroup_BDGReport",
                $"BDGReportGroup_MissingMasking",
                $"BDGReportGroup_BDGGLAccountMapping",
                $"BDGBudgetInfo",
                $"BDG_LRPGLTransaction",
                $"LRPVendor_Voucher_Distribution"
            };
        }
    }
}

