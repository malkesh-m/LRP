using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ValidationGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string ControlName { get; set; }
        public string TableName { get; set; }
        public string Operator { get; set; }
        public string Argument { get; set; }
        public bool ValidateEmpty { get; set; }
        public bool IsWarning { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
