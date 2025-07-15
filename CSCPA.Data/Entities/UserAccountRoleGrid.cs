using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class UserAccountRoleGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid UserAccountId { get; set; }
        public string Role { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
