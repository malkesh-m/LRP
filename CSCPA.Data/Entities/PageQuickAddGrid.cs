using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class PageQuickAddGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid PageId { get; set; }
        public string Name { get; set; }
        public string QuickAddPageLink { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
