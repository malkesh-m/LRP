using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBudgetsetupTemp
    {
        public decimal? CurrentYearBudgetAmount { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public string Bdgaccountgroupname { get; set; }
        public Guid BdgbudgetinfoDetailid { get; set; }
        public int SortOrder { get; set; }
        public string Yearsetupname { get; set; }
    }
}
