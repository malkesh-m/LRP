using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ReferenceAttachmentGrid
    {
        public Guid ReferenceId { get; set; }
        public string Type { get; set; }
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Download { get; set; }
        public string Source { get; set; }
        public Guid? PortalId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? NoMin { get; set; }
    }
}
