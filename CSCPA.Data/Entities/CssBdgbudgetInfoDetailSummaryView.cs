using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgbudgetInfoDetailSummaryView
    {
        public decimal? Budgetamount { get; set; }
        public decimal? Currentyearbudget { get; set; }
        public decimal? Nextyearbudgetamount { get; set; }
        public Guid Bdgbudgetinfoid { get; set; }
    }
}
