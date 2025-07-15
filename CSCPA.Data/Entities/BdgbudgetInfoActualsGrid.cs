using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetInfoActualsGrid
    {
        public Guid ObjectUid { get; set; }
        public string YearSetup { get; set; }
        public string Department { get; set; }
        public string AccountGroup { get; set; }
        public decimal? YtdactualsAmount { get; set; }
        public decimal? YtdprojectedAmount { get; set; }
        public decimal? PybudgetAmount { get; set; }
        public decimal? CybudgetAmount { get; set; }
        public decimal? NybudgetAmount { get; set; }
        public decimal? DollarIncrease { get; set; }
        public decimal? PercentIncrease { get; set; }
        public bool Override { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgcompanyId { get; set; }
        public Guid BdgaccountGroupId { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public Guid YearSetupId { get; set; }
        public int SortOrder { get; set; }
        public decimal? OriginialBudgetAmount { get; set; }
        public decimal? OriginalNextYearBudgetAmount { get; set; }
        public decimal? YtdbudgetAmount { get; set; }
        public decimal? TwoMoreYearsBudgetAmount { get; set; }
        public decimal? CurrentMonthAmount { get; set; }
        public decimal? VarianceYtdbudgetAmount { get; set; }
        public string StatusValue { get; set; }
        public decimal? VarianceTwoMoreYearsBudgetAmount { get; set; }
        public decimal? VarianceNextYearBudgetAmount { get; set; }
        public decimal? VarianceBudgetAmount { get; set; }
        public decimal? OriginialTwoMoreYearsBudgetAmount { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string VarStatus { get; set; }
        public decimal? CurrentMonthBudget { get; set; }
        public decimal? VarianceCurrentMonthBudget { get; set; }
    }
}
