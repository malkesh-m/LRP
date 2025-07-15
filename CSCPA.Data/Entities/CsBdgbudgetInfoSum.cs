using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsBdgbudgetInfoSum
    {
        public decimal? BudgetAmount { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
    }
}
