using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpcodeLrpreportGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid LrpcodeId { get; set; }
        public string Report { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
