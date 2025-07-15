using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Lrpten99TaxTypeGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string ValueGp { get; set; }
        public string DescriptionBp { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
