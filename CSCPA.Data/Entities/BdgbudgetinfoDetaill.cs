using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetinfoDetaill
    {
        public Guid BdgbudgetInfoId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid? BdgbudgetGroupTypeId { get; set; }
        public string Description { get; set; }
        public string LineNumber { get; set; }
        public decimal? CurrentYearBudgetAmount { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? NextYearBudgetAmount { get; set; }
        public Guid? FringeBdgbudgetInfoDetailId { get; set; }
        public decimal? DetailAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public Guid? BdgaccountGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupId { get; set; }
        public Guid? BdgemployeeId { get; set; }
        public Guid? BdgemployeeTypeId { get; set; }
        public Guid? BdgemployeeUnitId { get; set; }
        public Guid? BdgemployeeStatusId { get; set; }
        public Guid? BdgemployeePositionId { get; set; }
        public Guid? BdgemployeeUnitPositionId { get; set; }
        public Guid? BdgpositionTypeId { get; set; }
        public Guid? BdgemployeeUnitPositionStepId { get; set; }
        public Guid? BdgemployeeCategoryId { get; set; }
        public Guid? AnticipatedStartingMonthId { get; set; }
        public decimal? WeeklySalary { get; set; }
        public int? NumberOfWeeks { get; set; }
        public int? NumberOfWeeksInNextYear { get; set; }
        public int? NumberOfMonthsOnSabbatical { get; set; }
        public int? NumberOfMonthsOnSabbaticalInNextYear { get; set; }
        public string MeetingLocation { get; set; }
        public string MeetingStartDate { get; set; }
        public Guid? BdgmeetingStatusId { get; set; }
        public decimal? Salary { get; set; }
        public Guid? WillBeUsingTaskForcesYesNoId { get; set; }
        public Guid? BdgcommitteeTypeId { get; set; }
        public Guid? BdgprojectTypeId { get; set; }
        public Guid? OldBdgbudgetInfoId { get; set; }
        public bool Override { get; set; }
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
        public Guid? BdgaccountGroupSubGroupSubGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupSubGroupSubGroupId { get; set; }
    }
}
