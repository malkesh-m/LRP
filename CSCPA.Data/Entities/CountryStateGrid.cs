using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CountryStateGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
