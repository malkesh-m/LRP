using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class QuickAddSettingGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string QuickAddLink { get; set; }
        public bool QuickAddEnabled { get; set; }
        public string PageTableNames { get; set; }
        public string QuickAddTableNames { get; set; }
        public string QuickAddNames { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
