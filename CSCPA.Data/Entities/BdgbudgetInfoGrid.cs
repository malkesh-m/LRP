using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetInfoGrid
    {
        public Guid ObjectUid { get; set; }
        public string YearSetup { get; set; }
        public string Department { get; set; }
        public string AccountGroup { get; set; }
        public decimal? YtdactualAmount { get; set; }
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
        public int Statusvalue { get; set; }
        public string AccountName { get; set; }
        public string Number { get; set; }
        public string AccountCode { get; set; }
        public string OrderNew { get; set; }
        public string Main { get; set; }
        public decimal? BudgetJuly { get; set; }
        public decimal? BudgetAug { get; set; }
        public decimal? BudgetSept { get; set; }
        public decimal? BudgetOct { get; set; }
        public decimal? BudgetNov { get; set; }
        public decimal? BudgetDec { get; set; }
        public decimal? BudgetJan { get; set; }
        public decimal? BudgetFeb { get; set; }
        public decimal? BudgetMar { get; set; }
        public decimal? BudgetApr { get; set; }
        public decimal? BudgetMay { get; set; }
        public decimal? BudgetJune { get; set; }
        public decimal? ActualJuly { get; set; }
        public decimal? ActualAug { get; set; }
        public decimal? ActualSept { get; set; }
        public decimal? ActualOct { get; set; }
        public decimal? ActualNov { get; set; }
        public decimal? ActualDec { get; set; }
        public decimal? ActualJan { get; set; }
        public decimal? ActualFeb { get; set; }
        public decimal? ActualMar { get; set; }
        public decimal? ActualApr { get; set; }
        public decimal? ActualMay { get; set; }
        public decimal? ActualJune { get; set; }
    }
}
