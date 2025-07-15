using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgreportParameter
    {
        public Guid BdgreportId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string ParameterDisplayName { get; set; }
        public Guid BdgreportParameterTypeId { get; set; }
        public string ParameterDatabaseFieldName { get; set; }
        public DateTime? ParameterDefaultStartValue { get; set; }
        public DateTime? ParameterDefaultEndValue { get; set; }
        public string ParameterDefaultValue { get; set; }
        public bool AllowMultipleValue { get; set; }
        public bool IsRangeValue { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int RecordId { get; set; }
        public int? OldRecordId { get; set; }
        public Guid? InstallationUid { get; set; }
        public string ImportedObjectUid { get; set; }

        public virtual Bdgreport Bdgreport { get; set; }
        public virtual BdgreportParameterType BdgreportParameterType { get; set; }
    }
}
