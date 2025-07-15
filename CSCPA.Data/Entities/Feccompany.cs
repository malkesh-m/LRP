using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Feccompany
    {
        public Feccompany()
        {
            Feccandidates = new HashSet<Feccandidate>();
            FeccashAccounts = new HashSet<FeccashAccount>();
            Feccommittees = new HashSet<Feccommittee>();
            FeccompanyFecsegmentValues = new HashSet<FeccompanyFecsegmentValue>();
            FeccompanyFecsegments = new HashSet<FeccompanyFecsegment>();
            FeccontributionSources = new HashSet<FeccontributionSource>();
            Feccontributions = new HashSet<Feccontribution>();
            FecdisbursementTypes = new HashSet<FecdisbursementType>();
            Fecdistributions = new HashSet<Fecdistribution>();
            FecexpenseCategories = new HashSet<FecexpenseCategory>();
            FecfilingFrequencies = new HashSet<FecfilingFrequency>();
            FecinterestGroupCategories = new HashSet<FecinterestGroupCategory>();
            FeclocalUnions = new HashSet<FeclocalUnion>();
            Fecmembers = new HashSet<Fecmember>();
            Fecreports = new HashSet<Fecreport>();
            Fecvendors = new HashSet<Fecvendor>();
            InverseParentFeccompany = new HashSet<Feccompany>();
            UserAccountFeccompanies = new HashSet<UserAccountFeccompany>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string AddressLineIii { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CountryStateId { get; set; }
        public Guid? ParentFeccompanyId { get; set; }
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
        public Guid? FecBdgreportGroupId { get; set; }
        public Guid? DefaultFeccontributionTypeId { get; set; }

        public virtual Country Country { get; set; }
        public virtual CountryState CountryState { get; set; }
        public virtual FeccontributionType DefaultFeccontributionType { get; set; }
        public virtual BdgreportGroup FecBdgreportGroup { get; set; }
        public virtual Feccompany ParentFeccompany { get; set; }
        public virtual ICollection<Feccandidate> Feccandidates { get; set; }
        public virtual ICollection<FeccashAccount> FeccashAccounts { get; set; }
        public virtual ICollection<Feccommittee> Feccommittees { get; set; }
        public virtual ICollection<FeccompanyFecsegmentValue> FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FeccompanyFecsegment> FeccompanyFecsegments { get; set; }
        public virtual ICollection<FeccontributionSource> FeccontributionSources { get; set; }
        public virtual ICollection<Feccontribution> Feccontributions { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypes { get; set; }
        public virtual ICollection<Fecdistribution> Fecdistributions { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategories { get; set; }
        public virtual ICollection<FecfilingFrequency> FecfilingFrequencies { get; set; }
        public virtual ICollection<FecinterestGroupCategory> FecinterestGroupCategories { get; set; }
        public virtual ICollection<FeclocalUnion> FeclocalUnions { get; set; }
        public virtual ICollection<Fecmember> Fecmembers { get; set; }
        public virtual ICollection<Fecreport> Fecreports { get; set; }
        public virtual ICollection<Fecvendor> Fecvendors { get; set; }
        public virtual ICollection<Feccompany> InverseParentFeccompany { get; set; }
        public virtual ICollection<UserAccountFeccompany> UserAccountFeccompanies { get; set; }
    }
}
