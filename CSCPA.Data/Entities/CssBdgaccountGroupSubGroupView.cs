using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgaccountGroupSubGroupView
    {
        public string Name { get; set; }
        public Guid BdgaccountGroupId { get; set; }
        public int? MaxRecordid { get; set; }
        public int? Count1 { get; set; }
    }
}
