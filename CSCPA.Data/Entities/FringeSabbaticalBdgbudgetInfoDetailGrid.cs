using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FringeSabbaticalBdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public decimal? BudgetAmount { get; set; }
        public bool IsInactive { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public string Employee { get; set; }
        public decimal? Salary { get; set; }
        public int? OfMonthsOnSabbatical { get; set; }
        public int? OfMonthsOnSabbaticalInNextYear { get; set; }
    }
}
