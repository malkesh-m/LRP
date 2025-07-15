using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssReportTotal
    {
        public string YearRange { get; set; }
        public string Bdgdepartment { get; set; }
        public string BdgaccountGroup { get; set; }
        public string BdgaccountGroupSubGroup { get; set; }
        public string BdgaccountGroupSubGroupSubGroup { get; set; }
        public string BdgaccountGroupSubGroupSubGroupSubGroup { get; set; }
        public DateTime? Trandate { get; set; }
        public double? AmountSum { get; set; }
        public string Acct { get; set; }
        public string Seg1 { get; set; }
        public string Seg2 { get; set; }
        public string Seg3 { get; set; }
        public string Seg4 { get; set; }
        public string Seg5 { get; set; }
        public string DepartmentGroupName { get; set; }
        public int? SortOrderDepartment { get; set; }
        public string Lm2Code { get; set; }
        public int? SortOrder { get; set; }
    }
}
