using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecdisbursementTypeFecdistributionTypeGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid FecdisbursementTypeId { get; set; }
        public string DistributionType { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
