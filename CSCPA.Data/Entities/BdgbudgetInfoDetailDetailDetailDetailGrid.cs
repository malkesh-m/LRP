using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetInfoDetailDetailDetailDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoDetailDetailDetailId { get; set; }
        public string LineNumber { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? DetailAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string BdgaccountGroup { get; set; }
        public string BdgaccountGroupSubGroup { get; set; }
        public string Bdgemployee { get; set; }
        public string BdgemployeeType { get; set; }
        public string BdgemployeeUnit { get; set; }
        public string BdgemployeeStatus { get; set; }
        public string BdgemployeePosition { get; set; }
        public decimal? Salary { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
