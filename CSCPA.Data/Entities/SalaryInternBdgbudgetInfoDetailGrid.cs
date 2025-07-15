using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class SalaryInternBdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public bool IsInactive { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public decimal? WeeklySalary { get; set; }
        public int? OfWeeks { get; set; }
        public string Subject { get; set; }
        public decimal? BudgetAmount { get; set; }
        public int? OfWeeksInNextYear { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
    }
}
