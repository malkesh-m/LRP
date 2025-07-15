using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetInfoDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public string LineNumber { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public string FringeBdgbudgetInfoDetail { get; set; }
        public decimal? DetailAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string BdgaccountGroup { get; set; }
        public string BdgaccountGroupSubGroup { get; set; }
        public decimal? WeeklySalary { get; set; }
        public int? NumberOfWeeks { get; set; }
        public int? NumberOfWeeksInNextYear { get; set; }
        public int? NumberOfMonthsOnSabbatical { get; set; }
        public int? NumberOfMonthsOnSabbaticalInNextYear { get; set; }
        public string MeetingLocation { get; set; }
        public string MeetingStartDate { get; set; }
        public decimal? Salary { get; set; }
        public string OldBdgbudgetInfo { get; set; }
        public bool Override { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public decimal? Originialbudgetamount { get; set; }
        public decimal? YtdprojectedAmount { get; set; }
        public decimal? OriginalNextYearBudgetAmount { get; set; }
        public decimal? YtdbudgetAmount { get; set; }
        public decimal? TwoMoreYearsBudgetAmount { get; set; }
        public decimal? OriginialTwoMoreYearsBudgetAmount { get; set; }
        public string AccountCode { get; set; }
        public string Exclusion { get; set; }
        public string Bpl { get; set; }
        public string CurrentMonth { get; set; }
        public string SlotId { get; set; }
        public string EmployeePosition { get; set; }
        public string Comment { get; set; }
        public bool? Override2 { get; set; }
        public int? NumberOfWeeksInTwoMoreyears { get; set; }
        public int? NumberOfMembers { get; set; }
    }
}
