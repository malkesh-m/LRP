using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BudgetInfoMpcdetailReport
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
        public decimal? PydetailBudgetamount { get; set; }
        public decimal? CydetailBudgetAmount { get; set; }
        public decimal? NydetailBudgetAmount { get; set; }
        public string IsParent { get; set; }
        public string Description { get; set; }
        public decimal? HistoricYtdactualAmount { get; set; }
        public decimal? HistoricYtdprojectedAmount { get; set; }
        public decimal? HistoricBudgetAmount { get; set; }
        public Guid? BdgbudgetGroupTypeId { get; set; }
        public Guid? BdgreportGroupTypeId { get; set; }
    }
}
