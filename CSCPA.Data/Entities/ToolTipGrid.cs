using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ToolTipGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string Description { get; set; }
    }
}
