using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class DynamicFieldList
    {
        public Guid ModuleId { get; set; }
        public string Module { get; set; }
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string DynamicFieldType { get; set; }
        public string PossibleValue { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public int SortOrder { get; set; }
    }
}
