using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgemployeeTypeGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public decimal MultiplicativeFactor { get; set; }
        public decimal AdditiveFactor { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgcompanyId { get; set; }
    }
}
