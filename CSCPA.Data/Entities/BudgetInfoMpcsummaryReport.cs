using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BudgetInfoMpcsummaryReport
    {
        public Guid YearSetupId { get; set; }
        public string YearSetup { get; set; }
        public string YearCode { get; set; }
        public string PreviousYearSetup { get; set; }
        public string PreviousYearCode { get; set; }
        public string NextYearSetup { get; set; }
        public string NextYearCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public DateTime? PreviousStartDate { get; set; }
        public DateTime? PreviousEndDate { get; set; }
        public DateTime? PreviousActualStartDate { get; set; }
        public DateTime? PreviousActualEndDate { get; set; }
        public int? ReportGroupTypeSortOrder { get; set; }
        public string ReportGroupType { get; set; }
        public string Department { get; set; }
        public string BudgetGroupType { get; set; }
        public decimal PyprojectedAmount { get; set; }
        public decimal PybudgetAmount { get; set; }
        public decimal? CybudgetAmount { get; set; }
    }
}
