using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsBudgetInfoReportsp
    {
        public Guid Yearsetupid { get; set; }
        public Guid? BdgdepartmentGroupId { get; set; }
        public Guid BdgaccountGroupId { get; set; }
        public decimal? YtdactualAmount { get; set; }
        public decimal? YtdprojectedAmount { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? ProposedBudgetAmount { get; set; }
        public decimal? EstimatedBudgetAmount { get; set; }
    }
}
