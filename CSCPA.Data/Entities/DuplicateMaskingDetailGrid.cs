using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class DuplicateMaskingDetailGrid
    {
        public Guid BdgreportGroupDuplicateMaskingId { get; set; }
        public string AccountNo { get; set; }
        public Guid ObjectUid { get; set; }
        public string SubGroup { get; set; }
        public string SubSubGroup { get; set; }
        public string SubSubSubGroup { get; set; }
        public string Department { get; set; }
        public string AccountGroup { get; set; }
    }
}
