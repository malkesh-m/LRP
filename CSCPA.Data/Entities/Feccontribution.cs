using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Feccontribution
    {
        public Feccontribution()
        {
            FeccontributionDetails = new HashSet<FeccontributionDetail>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid FeccompanyId { get; set; }
        public Guid? FeclocalUnionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal? MemberTotal { get; set; }
        public Guid? FeccontributionTypeId { get; set; }
        public string CheckNo { get; set; }
        public DateTime? CheckDate { get; set; }
        public string GpreferenceNo { get; set; }
        public DateTime? DepositDate { get; set; }
        public Guid? FeccontributionStatusId { get; set; }
        public byte[] UploadDetail { get; set; }
        public Guid? FeccashAccountId { get; set; }
        public DateTime? DateReceived { get; set; }
        public Guid? FeccontributionSourceId { get; set; }
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
        public DateTime? ProcessDate { get; set; }

        public virtual FeccashAccount FeccashAccount { get; set; }
        public virtual Feccompany Feccompany { get; set; }
        public virtual FeccontributionSource FeccontributionSource { get; set; }
        public virtual FeccontributionStatus FeccontributionStatus { get; set; }
        public virtual FeccontributionType FeccontributionType { get; set; }
        public virtual FeclocalUnion FeclocalUnion { get; set; }
        public virtual ICollection<FeccontributionDetail> FeccontributionDetails { get; set; }
    }
}
