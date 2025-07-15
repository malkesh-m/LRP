using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgemployeeUnitPositionStep
    {
        public BdgemployeeUnitPositionStep()
        {
            BdgbudgetInfoDetails = new HashSet<BdgbudgetInfoDetail>();
        }

        public Guid BdgemployeeUnitPositionId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public decimal? Salary { get; set; }
        public decimal? PreviousYearSalary { get; set; }
        public decimal? CurrentYearSalary { get; set; }
        public Guid? BdgpositionTypeId { get; set; }
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

        public virtual BdgemployeeUnitPosition BdgemployeeUnitPosition { get; set; }
        public virtual BdgpositionType BdgpositionType { get; set; }
        public virtual ICollection<BdgbudgetInfoDetail> BdgbudgetInfoDetails { get; set; }
    }
}
