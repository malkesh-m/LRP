using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ExecutiveSummaryReport
    {
        public Guid YearSetupId { get; set; }
        public string YearCode { get; set; }
        public string PreviousYearCode { get; set; }
        public int DepartmentGroupSortOrder { get; set; }
        public string DepartmentGroup { get; set; }
        public int DepartmentSortOrder { get; set; }
        public string Department { get; set; }
        public string DepartmentNumber { get; set; }
        public decimal? Salaries { get; set; }
        public decimal? Fringes { get; set; }
        public decimal? OtherAdmin { get; set; }
        public decimal? Meetings { get; set; }
        public decimal? ProjectsPublications { get; set; }
        public decimal? Committees { get; set; }
        public decimal? Others { get; set; }
        public decimal? ApprovedBudget { get; set; }
    }
}
