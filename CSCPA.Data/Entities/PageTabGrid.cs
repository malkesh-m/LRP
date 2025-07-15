using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class PageTabGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid PageId { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string Control { get; set; }
        public string Module { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
