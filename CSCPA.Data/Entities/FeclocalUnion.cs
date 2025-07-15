using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FeclocalUnion
    {
        public FeclocalUnion()
        {
            FeccontributionDetails = new HashSet<FeccontributionDetail>();
            Feccontributions = new HashSet<Feccontribution>();
            Fecmembers = new HashSet<Fecmember>();
            UserAccountFeclocalUnions = new HashSet<UserAccountFeclocalUnion>();
        }

        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid FeccompanyId { get; set; }
        public string Number { get; set; }
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
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string City { get; set; }
        public Guid? CountryStateId { get; set; }
        public string PostalCode { get; set; }
        public string Display { get; set; }

        public virtual CountryState CountryState { get; set; }
        public virtual Feccompany Feccompany { get; set; }
        public virtual ICollection<FeccontributionDetail> FeccontributionDetails { get; set; }
        public virtual ICollection<Feccontribution> Feccontributions { get; set; }
        public virtual ICollection<Fecmember> Fecmembers { get; set; }
        public virtual ICollection<UserAccountFeclocalUnion> UserAccountFeclocalUnions { get; set; }
    }
}
