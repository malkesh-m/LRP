using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class DropDownSettingGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string DropDownNames { get; set; }
        public string FilterControlId { get; set; }
        public string TableOrViewName { get; set; }
        public string AdditionalFields { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string PageLinks { get; set; }
        public string DropDownTableNames { get; set; }
        public string PageTableNames { get; set; }
    }
}
