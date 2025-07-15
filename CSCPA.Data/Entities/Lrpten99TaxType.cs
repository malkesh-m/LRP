using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Lrpten99TaxType
    {
        public Lrpten99TaxType()
        {
            Fecdistributions = new HashSet<Fecdistribution>();
            Fecvendors = new HashSet<Fecvendor>();
            Lrpten99BoxNos = new HashSet<Lrpten99BoxNo>();
            LrpvendorVoucherChangeLogs = new HashSet<LrpvendorVoucherChangeLog>();
            LrpvendorVouchers = new HashSet<LrpvendorVoucher>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string ValueGp { get; set; }
        public string DescriptionBp { get; set; }
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

        public virtual ICollection<Fecdistribution> Fecdistributions { get; set; }
        public virtual ICollection<Fecvendor> Fecvendors { get; set; }
        public virtual ICollection<Lrpten99BoxNo> Lrpten99BoxNos { get; set; }
        public virtual ICollection<LrpvendorVoucherChangeLog> LrpvendorVoucherChangeLogs { get; set; }
        public virtual ICollection<LrpvendorVoucher> LrpvendorVouchers { get; set; }
    }
}
