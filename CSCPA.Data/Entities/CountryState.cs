using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CountryState
    {
        public CountryState()
        {
            Bdgcompanies = new HashSet<Bdgcompany>();
            FeccandidateCountryStates = new HashSet<Feccandidate>();
            FeccandidateElectionCountryStates = new HashSet<Feccandidate>();
            Feccommittees = new HashSet<Feccommittee>();
            Feccompanies = new HashSet<Feccompany>();
            FeccontributionDetails = new HashSet<FeccontributionDetail>();
            FecdistributionCandidateOrCommitteeCountryStates = new HashSet<Fecdistribution>();
            FecdistributionElectionCountryStates = new HashSet<Fecdistribution>();
            FecdistributionMailingCountryStates = new HashSet<Fecdistribution>();
            FecdistributionVendorCountryStates = new HashSet<Fecdistribution>();
            FeclocalUnions = new HashSet<FeclocalUnion>();
            Fecmembers = new HashSet<Fecmember>();
            Fecvendors = new HashSet<Fecvendor>();
            Lrpcompanies = new HashSet<Lrpcompany>();
            Lrpvendors = new HashSet<Lrpvendor>();
            UserAccounts = new HashSet<UserAccount>();
        }

        public Guid CountryId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
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

        public virtual Country Country { get; set; }
        public virtual ICollection<Bdgcompany> Bdgcompanies { get; set; }
        public virtual ICollection<Feccandidate> FeccandidateCountryStates { get; set; }
        public virtual ICollection<Feccandidate> FeccandidateElectionCountryStates { get; set; }
        public virtual ICollection<Feccommittee> Feccommittees { get; set; }
        public virtual ICollection<Feccompany> Feccompanies { get; set; }
        public virtual ICollection<FeccontributionDetail> FeccontributionDetails { get; set; }
        public virtual ICollection<Fecdistribution> FecdistributionCandidateOrCommitteeCountryStates { get; set; }
        public virtual ICollection<Fecdistribution> FecdistributionElectionCountryStates { get; set; }
        public virtual ICollection<Fecdistribution> FecdistributionMailingCountryStates { get; set; }
        public virtual ICollection<Fecdistribution> FecdistributionVendorCountryStates { get; set; }
        public virtual ICollection<FeclocalUnion> FeclocalUnions { get; set; }
        public virtual ICollection<Fecmember> Fecmembers { get; set; }
        public virtual ICollection<Fecvendor> Fecvendors { get; set; }
        public virtual ICollection<Lrpcompany> Lrpcompanies { get; set; }
        public virtual ICollection<Lrpvendor> Lrpvendors { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
