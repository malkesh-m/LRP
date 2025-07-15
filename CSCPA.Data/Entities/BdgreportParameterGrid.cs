using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgreportParameterGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgreportId { get; set; }
        public string ParameterDisplayName { get; set; }
        public string BdgreportParameterType { get; set; }
        public string ParameterDatabaseFieldName { get; set; }
        public DateTime? ParameterDefaultStartValue { get; set; }
        public DateTime? ParameterDefaultEndValue { get; set; }
        public string ParameterDefaultValue { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
