using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssChecknoApplied
    {
        public Guid Objectuid { get; set; }
        public DateTime? Documentdate { get; set; }
        public string Appliedtodocumentno { get; set; }
        public string Id { get; set; }
        public string DocumentNo { get; set; }
        public string Checkno { get; set; }
    }
}
