using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Feccommittee
    {
        public Feccommittee()
        {
            Fecdistributions = new HashSet<Fecdistribution>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid? FeccompanyId { get; set; }
        public string TreasurerName { get; set; }
        public string CommitteeIdentification { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string City { get; set; }
        public Guid? CountryStateId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public Guid? FeccommitteeTypeId { get; set; }
        public string Party { get; set; }
        public Guid? FecfilingFrequencyId { get; set; }
        public Guid? FecinterestGroupCategoryId { get; set; }
        public string ConnectedOrganizationName { get; set; }
        public string CandidateIdentification { get; set; }
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

        public virtual CountryState CountryState { get; set; }
        public virtual FeccommitteeType FeccommitteeType { get; set; }
        public virtual Feccompany Feccompany { get; set; }
        public virtual FecfilingFrequency FecfilingFrequency { get; set; }
        public virtual FecinterestGroupCategory FecinterestGroupCategory { get; set; }
        public virtual ICollection<Fecdistribution> Fecdistributions { get; set; }
    }
}
