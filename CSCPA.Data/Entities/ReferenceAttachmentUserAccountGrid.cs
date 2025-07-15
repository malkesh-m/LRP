using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ReferenceAttachmentUserAccountGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid ReferenceAttachmentId { get; set; }
        public string UserAccount { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
