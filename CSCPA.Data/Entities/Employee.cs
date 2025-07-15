using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Employee
    {
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string NameCombined { get; set; }
        public string NameAlias { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNo { get; set; }
        public Guid? Lm2receiptCodeId { get; set; }
        public Guid? Lm2disbursementCodeId { get; set; }
        public string Description { get; set; }
        public string GpStatus { get; set; }
        public string OaStatus { get; set; }
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
