using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Lrpcompany
    {
        public Lrpcompany()
        {
            InverseParentLrpcompany = new HashSet<Lrpcompany>();
            Lrpgltransactions = new HashSet<Lrpgltransaction>();
            Lrpvendors = new HashSet<Lrpvendor>();
            UserAccountLrpcompanies = new HashSet<UserAccountLrpcompany>();
        }
        public Guid ObjectUid { get; set;  }
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
        public Guid? ParentLrpcompanyId { get; set; }
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
        public virtual CountryState CountryState { get; set; }
        public virtual Lrpcompany ParentLrpcompany { get; set; }
        public virtual ICollection<Lrpcompany> InverseParentLrpcompany { get; set; }
        public virtual ICollection<Lrpgltransaction> Lrpgltransactions { get; set; }
        public virtual ICollection<Lrpvendor> Lrpvendors { get; set; }
        public virtual ICollection<UserAccountLrpcompany> UserAccountLrpcompanies { get; set; }
    }
}
