using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Bdggltransaction
    {
        public Bdggltransaction()
        {
            FecdistributionDetails = new HashSet<FecdistributionDetail>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid BdgcompanyId { get; set; }
        public string TransactionMonth { get; set; }
        public string TransactionYear { get; set; }
        public string JournalEntry { get; set; }
        public string SourceDocument { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string VendorId { get; set; }
        public string VendorNo { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? PostingDate { get; set; }
        public string CreditAmount { get; set; }
        public decimal? DebitAmount { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string ApplyToDocmentNo { get; set; }
        public string ApplyFromDocumentNo { get; set; }
        public string TransactionAccount { get; set; }
        public decimal? TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
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

        public virtual Bdgcompany Bdgcompany { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetails { get; set; }
    }
}
