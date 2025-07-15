using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class SalarySabbaticalBdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public bool IsInactive { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public string Employee { get; set; }
        public decimal? Salary { get; set; }
        public int? OfMonths { get; set; }
        public int? OfMonthsInNextYear { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public decimal? BudgetAmount { get; set; }
    }
}
