using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsBdgbudgetSumdetail
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string AccountCode { get; set; }
        public int? Count1 { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? ProposedBudgetAmount { get; set; }
        public decimal? Detailcurrentyearbudgetamount { get; set; }
        public decimal? DetailBudgetAmount { get; set; }
        public string Yearname { get; set; }
    }
}
