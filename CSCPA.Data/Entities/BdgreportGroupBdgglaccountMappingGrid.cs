using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgreportGroupBdgglaccountMappingGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgreportGroupId { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string AccountNo { get; set; }
        public string Department { get; set; }
        public string AccountGroup { get; set; }
        public string SubGroup { get; set; }
        public bool IsDeleted { get; set; }
        public string SubSubGroup { get; set; }
        public string SubSubSubGroup { get; set; }
    }
}
