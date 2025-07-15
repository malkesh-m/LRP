using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsTotalBudgetamountByBudgetinfoid
    {
        public decimal? Budgetamount { get; set; }
        public Guid Bdgbudgetinfoid { get; set; }
        public int? Count1 { get; set; }
    }
}
