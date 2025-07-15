using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BudgetInfoReportPermonth
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
        public Guid DepartmentId { get; set; }
        public string Department { get; set; }
        public string AccountGroup { get; set; }
        public int AccountGroupSortOrder { get; set; }
        public decimal? YtdactualAmount { get; set; }
        public decimal? YtdprojectedAmount { get; set; }
        public decimal? PybudgetAmount { get; set; }
        public decimal? CybudgetAmount { get; set; }
        public decimal? NybudgetAmount { get; set; }
        public string BudgetInfoDetailLine { get; set; }
        public decimal? CydetailBudgetAmount { get; set; }
        public decimal? NydetailBudgetAmount { get; set; }
        public string IsParent { get; set; }
        public string Description { get; set; }
        public decimal? LydetailBudgetAmount { get; set; }
        public int? BdgbudgetInfoDetailRecordId { get; set; }
        public decimal? DetailAmount { get; set; }
        public decimal? BudgetAmountP1 { get; set; }
        public decimal? BudgetAmountP2 { get; set; }
        public decimal? BudgetAmountP3 { get; set; }
        public decimal? BudgetAmountP4 { get; set; }
        public decimal? BudgetAmountP5 { get; set; }
        public decimal? BudgetAmountP6 { get; set; }
        public decimal? BudgetAmountP7 { get; set; }
        public decimal? BudgetAmountP8 { get; set; }
        public decimal? BudgetAmountP9 { get; set; }
        public decimal? BudgetAmountP10 { get; set; }
        public decimal? BudgetAmountP11 { get; set; }
        public decimal? BudgetAmountP12 { get; set; }
    }
}
