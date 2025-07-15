using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class EmailTemplateGrid
    {
        public Guid ObjectUid { get; set; }
        public string NotificationType { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string ToCc { get; set; }
        public string ToBcc { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
