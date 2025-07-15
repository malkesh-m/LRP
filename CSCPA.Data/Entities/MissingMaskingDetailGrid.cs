using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class MissingMaskingDetailGrid
    {
        public Guid BdgreportGroupMissingMaskingId { get; set; }
        public Guid BdgreportGroupId { get; set; }
        public string AccountNo { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string Acct { get; set; }
        public Guid ObjectUid { get; set; }
        public DateTime? Trandate { get; set; }
        public string Trandesc { get; set; }
        public string Trantype { get; set; }
        public double? Amount { get; set; }
    }
}
