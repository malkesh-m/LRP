using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FeccontributionGrid
    {
        public Guid ObjectUid { get; set; }
        public string Company { get; set; }
        public string LocalUnion { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal? MemberTotal { get; set; }
        public string ContributionType { get; set; }
        public string CheckNo { get; set; }
        public DateTime? CheckDate { get; set; }
        public string GpreferenceNo { get; set; }
        public DateTime? DepositDate { get; set; }
        public string ContributionStatus { get; set; }
        public byte[] UploadDetail { get; set; }
        public string CashAccount { get; set; }
        public DateTime? DateReceived { get; set; }
        public string ContributionSource { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid FeccompanyId { get; set; }
        public int RecordId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Batchno { get; set; }
    }
}
