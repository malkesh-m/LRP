using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class NotificationTemplateGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Template { get; set; }
        public bool? TestMode { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
