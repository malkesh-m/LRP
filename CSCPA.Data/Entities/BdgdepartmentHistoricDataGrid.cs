using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgdepartmentHistoricDataGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public string YearSetup { get; set; }
        public string BdgaccountGroup { get; set; }
        public string BdgreportGroupType { get; set; }
        public string BdgbudgetGroupType { get; set; }
        public decimal? YtdactualAmount { get; set; }
        public decimal? YtdprojectedAmount { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? ProposedBudgetAmount { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
