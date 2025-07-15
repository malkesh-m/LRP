using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetinfoChange
    {
        public DateTime? UpdateDatetime { get; set; }
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
    }
}
