using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgreportGroupDuplicateMaskingGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgreportGroupId { get; set; }
        public string AccountNo { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
