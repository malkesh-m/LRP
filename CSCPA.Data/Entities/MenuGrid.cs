using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class MenuGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string MenuLink { get; set; }
        public string MenuIconLink { get; set; }
        public string Module { get; set; }
        public bool ShowToAll { get; set; }
        public bool IsParent { get; set; }
        public string Parent { get; set; }
        public string Portal { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public int SortOrder { get; set; }
        public bool IsSeparator { get; set; }
    }
}
