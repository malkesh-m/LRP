using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgbudgetinfodetailamountsPm
    {
        public decimal? BudgetAmount { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public string EmployeeType { get; set; }
        public string AccountGroup { get; set; }
    }
}
