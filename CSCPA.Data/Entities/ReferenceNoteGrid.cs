using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ReferenceNoteGrid
    {
        public Guid ObjectUid { get; set; }
        public string Subject { get; set; }
        public string Module { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid ReferenceId { get; set; }
        public string Note { get; set; }
        public DateTime NoteDate { get; set; }
    }
}
