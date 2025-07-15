using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssEmployeeMoveFrom
    {
        public Guid ObjectUid { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
    }
}
