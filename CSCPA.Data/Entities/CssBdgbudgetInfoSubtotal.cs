using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgbudgetInfoSubtotal
    {
        public decimal? YtdactualAmount { get; set; }
        public decimal? YtdprojectedAmount { get; set; }
        public decimal? Budgetamount { get; set; }
        public decimal? ProposedBudgetAmount { get; set; }
        public decimal? Estimatedbudgetamount { get; set; }
        public Guid ObjectUid { get; set; }
    }
}
