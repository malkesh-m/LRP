using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class MeetingBdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public decimal? BudgetAmount { get; set; }
        public bool IsInactive { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public string Subject { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public string MeetingStartDate { get; set; }
        public string MeetingLocation { get; set; }
        public string BdgaccountSubGroup { get; set; }
        public string BdgaccountSubGroupSubGroup { get; set; }
        public decimal? YtdActuals { get; set; }
    }
}
