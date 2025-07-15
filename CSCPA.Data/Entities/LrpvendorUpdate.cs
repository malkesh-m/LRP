using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorUpdate
    {
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string VendorNo { get; set; }
        public Guid? LrpvendorClassId { get; set; }
        public Guid? LrpvendorMasterId { get; set; }
        public Guid? LrpcompanyId { get; set; }
        public string ContactName { get; set; }
        public string AddressI { get; set; }
        public string AddressIi { get; set; }
        public string AddressIii { get; set; }
        public string City { get; set; }
        public Guid? CountryStateId { get; set; }
        public string PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public string Userdef1 { get; set; }
        public string Userdef2 { get; set; }
        public string LastUpdateGpuserId { get; set; }
        public DateTime? LastUpdateGpdate { get; set; }
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
