using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class SalaryBdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public string LineNumber { get; set; }
        public decimal? BudgetAmount { get; set; }
        public string SubGroup { get; set; }
        public bool IsInactive { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public decimal? DetailAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string AccountGroup { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public decimal? Salary { get; set; }
        public string Subject { get; set; }
    }
}
