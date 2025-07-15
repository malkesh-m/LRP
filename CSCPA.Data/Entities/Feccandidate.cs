using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Feccandidate
    {
        public Feccandidate()
        {
            Fecdistributions = new HashSet<Fecdistribution>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid FeccompanyId { get; set; }
        public string CandidateIdentification { get; set; }
        public string PartyDesignationI { get; set; }
        public string Filler { get; set; }
        public string PartyDesignationIii { get; set; }
        public Guid? FeccandidateTypeId { get; set; }
        public string FillerIi { get; set; }
        public Guid? FeccandidateStatusId { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string City { get; set; }
        public Guid? CountryStateId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string PrincipalCampaignComm { get; set; }
        public string YearOfElection { get; set; }
        public string CurrentDistrict { get; set; }
        public Guid? FecelectionOfficeId { get; set; }
        public Guid? ElectionCountryStateId { get; set; }
        public string ElectionDistrict { get; set; }
        public string ElectionOtherIdentification { get; set; }
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
        public virtual CountryState ElectionCountryState { get; set; }
        public virtual FeccandidateStatus FeccandidateStatus { get; set; }
        public virtual FeccandidateType FeccandidateType { get; set; }
        public virtual Feccompany Feccompany { get; set; }
        public virtual FecelectionOffice FecelectionOffice { get; set; }
        public virtual ICollection<Fecdistribution> Fecdistributions { get; set; }
    }
}
