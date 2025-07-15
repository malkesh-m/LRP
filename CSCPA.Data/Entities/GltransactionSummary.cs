using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class GltransactionSummary
    {
        public Guid GlyearCodeId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public decimal ItemizedAmount { get; set; }
        public decimal NonItemizedAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid? YearSetupId { get; set; }
        public Guid? CodeId { get; set; }
        public string Year { get; set; }
        public string Code { get; set; }
        public string Id { get; set; }
        public string RoomOrBox { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Type { get; set; }
        public string Purpose { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string CheckNumber { get; set; }
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
        public string Cpnyid { get; set; }
    }
}
