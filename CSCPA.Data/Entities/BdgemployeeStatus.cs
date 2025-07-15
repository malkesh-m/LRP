using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgemployeeStatus
    {
        public BdgemployeeStatus()
        {
            BdgbudgetInfoDetailDetailDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetailDetailDetail>();
            BdgbudgetInfoDetailDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetailDetail>();
            BdgbudgetInfoDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetail>();
            BdgbudgetInfoDetails = new HashSet<BdgbudgetInfoDetail>();
            BdgemployeeEmployeeHistories = new HashSet<BdgemployeeEmployeeHistory>();
            Bdgemployees = new HashSet<Bdgemployee>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid BdgcompanyId { get; set; }
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

        public virtual Bdgcompany Bdgcompany { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetailDetailDetail> BdgbudgetInfoDetailDetailDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetailDetail> BdgbudgetInfoDetailDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetail> BdgbudgetInfoDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetail> BdgbudgetInfoDetails { get; set; }
        public virtual ICollection<BdgemployeeEmployeeHistory> BdgemployeeEmployeeHistories { get; set; }
        public virtual ICollection<Bdgemployee> Bdgemployees { get; set; }
    }
}
