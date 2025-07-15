using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsBdgbudgetCount
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string AccountCode { get; set; }
        public int? Count1 { get; set; }
    }
}
