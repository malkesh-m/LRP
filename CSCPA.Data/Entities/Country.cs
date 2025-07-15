using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Country
    {
        public Country()
        {
            Bdgcompanies = new HashSet<Bdgcompany>();
            CountryStates = new HashSet<CountryState>();
            Feccompanies = new HashSet<Feccompany>();
            Fecvendors = new HashSet<Fecvendor>();
            Lrpcompanies = new HashSet<Lrpcompany>();
            Lrpvendors = new HashSet<Lrpvendor>();
            UserAccounts = new HashSet<UserAccount>();
        }

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

        public virtual ICollection<Bdgcompany> Bdgcompanies { get; set; }
        public virtual ICollection<CountryState> CountryStates { get; set; }
        public virtual ICollection<Feccompany> Feccompanies { get; set; }
        public virtual ICollection<Fecvendor> Fecvendors { get; set; }
        public virtual ICollection<Lrpcompany> Lrpcompanies { get; set; }
        public virtual ICollection<Lrpvendor> Lrpvendors { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
