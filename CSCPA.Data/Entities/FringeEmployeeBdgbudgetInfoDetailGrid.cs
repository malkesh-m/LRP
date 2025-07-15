using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FringeEmployeeBdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public decimal? BudgetAmount { get; set; }
        public bool IsInactive { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string Unit { get; set; }
        public decimal? Salary { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
    }
}
