using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssUpdateAllDataStatus
    {
        public Guid Objectuid { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Statusvalue { get; set; }
        public int RecordId { get; set; }
    }
}
