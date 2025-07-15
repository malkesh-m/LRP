using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgreportTypeGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgcompanyId { get; set; }
        public bool IsAdminReport { get; set; }
        public string ReportName { get; set; }
    }
}
