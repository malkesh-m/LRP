using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class EquipmentRentalBdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public bool IsInactive { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public string Subject { get; set; }
        public string CommitteeType { get; set; }
        public string WillBeUsingTaskForces { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public decimal? BudgetAmount { get; set; }
    }
}
