using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class RoleModule
    {
        public Guid RoleId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid ModuleId { get; set; }
        public bool AddPage { get; set; }
        public bool EditPage { get; set; }
        public bool ViewPage { get; set; }
        public bool TablePage { get; set; }
        public bool TableNew { get; set; }
        public bool TableCopy { get; set; }
        public bool TableDelete { get; set; }
        public bool TableCsv { get; set; }
        public bool TablePdf { get; set; }
        public bool TableWord { get; set; }
        public bool TableExcel { get; set; }
        public bool TableRefresh { get; set; }
        public bool TableReset { get; set; }
        public bool AddPageSave { get; set; }
        public bool AddPageSaveAndClose { get; set; }
        public bool AddPageSaveAndNew { get; set; }
        public bool EditPageSave { get; set; }
        public bool EditPageSaveAndClose { get; set; }
        public bool EditPageDelete { get; set; }
        public bool PageHelp { get; set; }
        public bool PageQuickAdd { get; set; }
        public bool Upload { get; set; }
        public bool Download { get; set; }
        public bool CustomA { get; set; }
        public bool CustomB { get; set; }
        public bool CustomC { get; set; }
        public bool CustomD { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int RecordId { get; set; }
        public int? OldRecordId { get; set; }
        public Guid? InstallationUid { get; set; }
        public string ImportedObjectUid { get; set; }

        public virtual Module Module { get; set; }
        public virtual Role Role { get; set; }
    }
}
