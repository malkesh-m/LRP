using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetInfoView
    {
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid YearSetupId { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public Guid BdgaccountGroupId { get; set; }
        public decimal? YtdactualAmount { get; set; }
        public decimal? YtdprojectedAmount { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? ProposedBudgetAmount { get; set; }
        public decimal? EstimatedBudgetAmount { get; set; }
        public decimal? DollarIncrease { get; set; }
        public decimal? PercentIncrease { get; set; }
        public bool Override { get; set; }
        public Guid BdgcompanyId { get; set; }
        public Guid? BdgreportTypeId { get; set; }
        public Guid? PreviousBdgbudgetInfoId { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int RecordId { get; set; }
        public int? OldRecordId { get; set; }
        public Guid? InstallationUid { get; set; }
        public string ImportedObjectUid { get; set; }
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
        public decimal? ProposedBudgetAmountPdiff { get; set; }
        public decimal? YtdbudgetAmount { get; set; }
        public decimal? OriginialBudgetAmount { get; set; }
        public decimal? OriginalNextYearBudgetAmount { get; set; }
        public decimal? OriginialTwoMoreYearsBudgetAmount { get; set; }
        public decimal? TwoMoreYearsBudgetAmount { get; set; }
        public decimal? CurrentMonth { get; set; }
        public decimal? CurrentMonthBudget { get; set; }
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
        public Guid? CssStatusid { get; set; }
    }
}
