using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class BdgreportParameterAddEditModel
    {
        public Guid BdgreportId { get; set; }
        public Guid? ObjectUID { get; set; }
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
    }
    public class BdgreportParameterListModel
    {
        public Guid BdgreportId { get; set; }
        public Guid ObjectUID { get; set; }
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
    }
}
