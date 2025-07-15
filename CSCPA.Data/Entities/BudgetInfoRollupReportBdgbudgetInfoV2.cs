using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BudgetInfoRollupReportBdgbudgetInfoV2
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
        public string IsParent { get; set; }
        public decimal? ProposedBudgetAmountP1 { get; set; }
        public decimal? ProposedBudgetAmountP2 { get; set; }
        public decimal? ProposedBudgetAmountP3 { get; set; }
        public decimal? ProposedBudgetAmountP4 { get; set; }
        public decimal? ProposedBudgetAmountP5 { get; set; }
        public decimal? ProposedBudgetAmountP6 { get; set; }
        public decimal? ProposedBudgetAmountP7 { get; set; }
        public decimal? ProposedBudgetAmountP8 { get; set; }
        public decimal? ProposedBudgetAmountP9 { get; set; }
        public decimal? ProposedBudgetAmountP10 { get; set; }
        public decimal? ProposedBudgetAmountP11 { get; set; }
        public decimal? ProposedBudgetAmountP12 { get; set; }
    }
}
