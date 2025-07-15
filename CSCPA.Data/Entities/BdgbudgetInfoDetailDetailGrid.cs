using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetInfoDetailDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoDetailId { get; set; }
        public string LineNumber { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? DetailAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string BdgaccountGroup { get; set; }
        public string BdgaccountGroupSubGroup { get; set; }
        public decimal? Salary { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
