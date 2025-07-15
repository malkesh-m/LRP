using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class UserAccountRolePermissionList
    {
        public Guid UserAccountId { get; set; }
        public Guid ModuleId { get; set; }
        public int? AddPage { get; set; }
        public int? EditPage { get; set; }
        public int? ViewPage { get; set; }
        public int? TablePage { get; set; }
        public int? TableNew { get; set; }
        public int? TableCopy { get; set; }
        public int? TableDelete { get; set; }
        public int? TableCsv { get; set; }
        public int? TablePdf { get; set; }
        public int? TableWord { get; set; }
        public int? TableExcel { get; set; }
        public int? TableRefresh { get; set; }
        public int? TableReset { get; set; }
        public int? AddPageSave { get; set; }
        public int? AddPageSaveAndClose { get; set; }
        public int? AddPageSaveAndNew { get; set; }
        public int? EditPageSave { get; set; }
        public int? EditPageSaveAndClose { get; set; }
        public int? EditPageDelete { get; set; }
        public int? PageHelp { get; set; }
        public int? PageQuickAdd { get; set; }
        public int? Upload { get; set; }
        public int? Download { get; set; }
        public int? CustomA { get; set; }
        public int? CustomB { get; set; }
        public int? CustomC { get; set; }
        public int? CustomD { get; set; }
    }
}
