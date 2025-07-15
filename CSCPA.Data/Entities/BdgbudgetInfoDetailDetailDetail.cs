using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetInfoDetailDetailDetail
    {
        public BdgbudgetInfoDetailDetailDetail()
        {
            BdgbudgetInfoDetailDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetailDetail>();
        }

        public Guid BdgbudgetInfoDetailDetailId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Description { get; set; }
        public string LineNumber { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? DetailAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public Guid? BdgaccountGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupId { get; set; }
        public Guid? BdgemployeeId { get; set; }
        public Guid? BdgemployeeTypeId { get; set; }
        public Guid? BdgemployeeUnitId { get; set; }
        public Guid? BdgemployeeStatusId { get; set; }
        public Guid? BdgemployeePositionId { get; set; }
        public decimal? Salary { get; set; }
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

        public virtual BdgaccountGroup BdgaccountGroup { get; set; }
        public virtual BdgaccountGroupSubGroup BdgaccountGroupSubGroup { get; set; }
        public virtual BdgbudgetInfoDetailDetail BdgbudgetInfoDetailDetail { get; set; }
        public virtual Bdgemployee Bdgemployee { get; set; }
        public virtual BdgemployeePosition BdgemployeePosition { get; set; }
        public virtual BdgemployeeStatus BdgemployeeStatus { get; set; }
        public virtual BdgemployeeType BdgemployeeType { get; set; }
        public virtual BdgemployeeUnit BdgemployeeUnit { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetailDetail> BdgbudgetInfoDetailDetailDetailDetails { get; set; }
    }
}
