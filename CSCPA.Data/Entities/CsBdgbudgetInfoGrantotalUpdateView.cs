using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsBdgbudgetInfoGrantotalUpdateView
    {
        public decimal? Currentmonth { get; set; }
        public decimal? Currentmonthbudget { get; set; }
        public decimal? YtdbudgetAmount { get; set; }
        public decimal? YtdactualAmount { get; set; }
        public Guid Bdgdepartmentid { get; set; }
        public Guid Yearsetupid { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
