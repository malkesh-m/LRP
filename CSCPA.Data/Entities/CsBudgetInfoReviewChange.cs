using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsBudgetInfoReviewChange
    {
        public string Acctgroupname { get; set; }
        public string Deptname { get; set; }
        public string Deptno { get; set; }
        public string Accountcode { get; set; }
        public decimal? HdBudgetamountLy { get; set; }
        public decimal? HdBudgetamoutCy { get; set; }
        public decimal? HdBudgetamountNy { get; set; }
        public decimal? HdYtdactualAmount { get; set; }
        public decimal? HdYtdprojectedAmount { get; set; }
        public decimal? DtBudgetamountLy { get; set; }
        public decimal? DtBudgetamoutCy { get; set; }
        public decimal? DtBudgetamountNy { get; set; }
        public string LineName { get; set; }
        public string Linedescription { get; set; }
        public string Name { get; set; }
        public string Yearname { get; set; }
        public int Linerecordid { get; set; }
        public DateTime Processdatedetail { get; set; }
        public DateTime Processdatehd { get; set; }
    }
}
