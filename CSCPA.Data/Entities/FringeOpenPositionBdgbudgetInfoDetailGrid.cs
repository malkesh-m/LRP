using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FringeOpenPositionBdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public decimal? BudgetAmount { get; set; }
        public bool IsInactive { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public string Unit { get; set; }
        public decimal? Salary { get; set; }
        public string UnitPosition { get; set; }
        public string Step { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public int RecordId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string PositionType { get; set; }
        public string AnticipatedStartingMonth { get; set; }
    }
}
