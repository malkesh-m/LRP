using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsSalaryFringeStep1
    {
        public string Fringeacct { get; set; }
        public string Bagsname { get; set; }
        public string Linenumber { get; set; }
        public string Bbidname { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public Guid YearSetupId { get; set; }
    }
}
