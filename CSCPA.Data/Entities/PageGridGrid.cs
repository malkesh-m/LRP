using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class PageGridGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid PageId { get; set; }
        public string ViewName { get; set; }
        public string TableName { get; set; }
        public string PrimaryKeyName { get; set; }
        public string ParentPrimaryKeyName { get; set; }
        public string InitialDisplayField { get; set; }
        public bool UseDetailView { get; set; }
        public bool UseShowAddGrid { get; set; }
        public string AddPageLink { get; set; }
        public string ViewPageLink { get; set; }
        public string EditPageLink { get; set; }
        public string CopyPageLink { get; set; }
        public bool AddPagePopup { get; set; }
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
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public bool UseRowLevelSecurity { get; set; }
    }
}
