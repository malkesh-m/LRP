using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BudgetInfoReport
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
        public string AccountGroup2 { get; set; }
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
        public decimal? ProposedBudgetAmountp1 { get; set; }
        public decimal? ProposedBudgetAmountp2 { get; set; }
        public decimal? ProposedBudgetAmountp3 { get; set; }
        public decimal? ProposedBudgetAmountp4 { get; set; }
        public decimal? ProposedBudgetAmountp5 { get; set; }
        public decimal? ProposedBudgetAmountp6 { get; set; }
        public decimal? ProposedBudgetAmountp7 { get; set; }
        public decimal? ProposedBudgetAmountp8 { get; set; }
        public decimal? ProposedBudgetAmountp9 { get; set; }
        public decimal? ProposedBudgetAmountp10 { get; set; }
        public decimal? ProposedBudgetAmountp11 { get; set; }
        public decimal? ProposedBudgetAmountp12 { get; set; }
        public decimal? YtdbudgetAmount { get; set; }
        public decimal? CurrentAmountP1 { get; set; }
        public decimal? CurrentAmountP2 { get; set; }
        public decimal? CurrentAmountP3 { get; set; }
        public decimal? CurrentAmountP4 { get; set; }
        public decimal? CurrentAmountP5 { get; set; }
        public decimal? CurrentAmountP6 { get; set; }
        public decimal? CurrentAmountP7 { get; set; }
        public decimal? CurrentAmountP8 { get; set; }
        public decimal? CurrentAmountP9 { get; set; }
        public decimal? CurrentAmountP10 { get; set; }
        public decimal? CurrentAmountP11 { get; set; }
        public decimal? CurrentAmountP12 { get; set; }
        public decimal? CurrentMonth { get; set; }
        public decimal? CurrentMonthBudget { get; set; }
        public string AccountGroup { get; set; }
        public Guid Objectuid { get; set; }
    }
}
