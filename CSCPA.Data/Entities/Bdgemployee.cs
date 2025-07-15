using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Bdgemployee
    {
        public Bdgemployee()
        {
            BdgbudgetInfoDetailDetailDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetailDetailDetail>();
            BdgbudgetInfoDetailDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetailDetail>();
            BdgbudgetInfoDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetail>();
            BdgbudgetInfoDetails = new HashSet<BdgbudgetInfoDetail>();
            BdgemployeeEmployeeHistories = new HashSet<BdgemployeeEmployeeHistory>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Number { get; set; }
        public Guid? BdgdepartmentId { get; set; }
        public Guid? BdgemployeePositionId { get; set; }
        public Guid? BdgemployeeStatusId { get; set; }
        public Guid? BdgemployeeUnitId { get; set; }
        public DateTime? HireDate { get; set; }
        public string InitialBudgetYear { get; set; }
        public decimal? AnnualSalary { get; set; }
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
        public virtual Bdgdepartment Bdgdepartment { get; set; }
        public virtual BdgemployeePosition BdgemployeePosition { get; set; }
        public virtual BdgemployeeStatus BdgemployeeStatus { get; set; }
        public virtual BdgemployeeUnit BdgemployeeUnit { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetailDetailDetail> BdgbudgetInfoDetailDetailDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetailDetail> BdgbudgetInfoDetailDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetail> BdgbudgetInfoDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetail> BdgbudgetInfoDetails { get; set; }
        public virtual ICollection<BdgemployeeEmployeeHistory> BdgemployeeEmployeeHistories { get; set; }
    }
}
