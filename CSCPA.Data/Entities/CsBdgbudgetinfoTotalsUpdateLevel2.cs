using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsBdgbudgetinfoTotalsUpdateLevel2
    {
        public string Bag01name { get; set; }
        public Guid? BdgbudgetInfoId { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public decimal? TwoMoreYearsBudgetAmount { get; set; }
        public decimal? OriginialBudgetAmount { get; set; }
        public decimal? OriginalNextYearBudgetAmount { get; set; }
        public decimal? OriginialTwoMoreYearsBudgetAmount { get; set; }
    }
}
