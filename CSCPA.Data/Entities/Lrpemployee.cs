using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Lrpemployee
    {
        public Lrpemployee()
        {
            LrptimeEntries = new HashSet<LrptimeEntry>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string EmployeeNo { get; set; }
        public Guid LrpdepartmentId { get; set; }
        public string JobTitle { get; set; }
        public DateTime? TermDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Guid? LrpcostCenterId { get; set; }
        public Guid? LrpemployeeTypeId { get; set; }
        public bool GrantWorker { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public Guid? LrpemployeeStatusId { get; set; }
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

        public virtual LrpcostCenter LrpcostCenter { get; set; }
        public virtual Lrpdepartment Lrpdepartment { get; set; }
        public virtual LrpemployeeStatus LrpemployeeStatus { get; set; }
        public virtual LrpemployeeType LrpemployeeType { get; set; }
        public virtual ICollection<LrptimeEntry> LrptimeEntries { get; set; }
    }
}
