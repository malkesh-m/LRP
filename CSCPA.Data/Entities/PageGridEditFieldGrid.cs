using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class PageGridEditFieldGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid PageGridId { get; set; }
        public string Name { get; set; }
        public string TableField { get; set; }
        public string ViewField { get; set; }
        public string FieldType { get; set; }
        public string DropDownTable { get; set; }
        public string DropDownDisplayColumn { get; set; }
        public string DropDownParentColumnName { get; set; }
        public string ExtendedAttributes { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
