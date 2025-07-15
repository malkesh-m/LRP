using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgemployeeAmount
    {
        public string Bdgemployeeunitname { get; set; }
        public string Positionname { get; set; }
        public decimal? PreviousYearSalary { get; set; }
        public decimal? CurrentYearSalary { get; set; }
        public decimal? Salary { get; set; }
        public string Stepname { get; set; }
    }
}
