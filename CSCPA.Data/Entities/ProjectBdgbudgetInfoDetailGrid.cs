using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ProjectBdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public decimal? BudgetAmount { get; set; }
        public bool IsInactive { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public string Subject { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public string ProjectType { get; set; }
        public string BdgaccountGroupSubGroup { get; set; }
        public string BdgaccountGroupSubGroupSubGroup { get; set; }
        public decimal? YtdActuals { get; set; }
    }
}
