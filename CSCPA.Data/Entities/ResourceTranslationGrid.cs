using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ResourceTranslationGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid ResourceId { get; set; }
        public string Name { get; set; }
        public string Localisation { get; set; }
        public string Module { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
