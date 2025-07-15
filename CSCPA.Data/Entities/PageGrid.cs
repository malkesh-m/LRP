using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class PageGrid
    {
        public PageGrid()
        {
            PageGridEditFields = new HashSet<PageGridEditField>();
        }

        public Guid PageId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string ViewName { get; set; }
        public string TableName { get; set; }
        public string PrimaryKeyName { get; set; }
        public string ParentPrimaryKeyName { get; set; }
        public string InitialDisplayField { get; set; }
        public bool UseDetailView { get; set; }
        public bool UseShowAddGrid { get; set; }
        public bool HideDataUntilSearched { get; set; }
        public bool DisableResizing { get; set; }
        public string AddPageLink { get; set; }
        public string ViewPageLink { get; set; }
        public string EditPageLink { get; set; }
        public string CopyPageLink { get; set; }
        public bool? AddPagePopup { get; set; }
        public bool EditPagePopup { get; set; }
        public bool ViewPagePopup { get; set; }
        public bool CopyPagePopup { get; set; }
        public bool ShowMyRecords { get; set; }
        public string FilterColumnI { get; set; }
        public string ComparisonOperatorI { get; set; }
        public string FilterValueLocationI { get; set; }
        public string FilterValueI { get; set; }
        public string LogicalOperatorI { get; set; }
        public string FilterColumnIi { get; set; }
        public string ComparisonOperatorIi { get; set; }
        public string FilterValueLocationIi { get; set; }
        public string FilterValueIi { get; set; }
        public string LogicalOperatorIi { get; set; }
        public string FilterColumnIii { get; set; }
        public string ComparisonOperatorIii { get; set; }
        public string FilterValueLocationIii { get; set; }
        public string FilterValueIii { get; set; }
        public string Spcommand { get; set; }
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
        public bool UseRowLevelSecurity { get; set; }

        public virtual Page Page { get; set; }
        public virtual ICollection<PageGridEditField> PageGridEditFields { get; set; }
    }
}
