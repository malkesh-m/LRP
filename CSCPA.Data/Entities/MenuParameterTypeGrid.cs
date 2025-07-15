using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class MenuParameterTypeGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid MenuId { get; set; }
        public string ParameterType { get; set; }
        public string ParameterValue { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
