using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecdistributionStatusStatusGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid FecdistributionStatusId { get; set; }
        public string AllowedStatus { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
