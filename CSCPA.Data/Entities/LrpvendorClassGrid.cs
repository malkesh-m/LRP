using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorClassGrid
    {
        public Guid ObjectUid { get; set; }
        public string VendorClassNo { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
    }
}
