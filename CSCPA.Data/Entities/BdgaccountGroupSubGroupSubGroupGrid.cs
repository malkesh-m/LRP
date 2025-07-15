using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgaccountGroupSubGroupSubGroupGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgaccountGroupSubGroupId { get; set; }
        public string Name { get; set; }
        public string AccountCode { get; set; }
        public string ParentBdgaccountGroupSubGroupSubGroup { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
