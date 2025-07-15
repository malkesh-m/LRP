using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgaccountGroupSubGroupGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgaccountGroupId { get; set; }
        public string Name { get; set; }
        public string AccountCode { get; set; }
        public string ParentSubGroup { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
