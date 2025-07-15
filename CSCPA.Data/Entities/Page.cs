using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Page
    {
        public Page()
        {
            PageGrids = new HashSet<PageGrid>();
            PageQuickAdds = new HashSet<PageQuickAdd>();
            PageTabControlPages = new HashSet<PageTab>();
            PageTabHeaderControlPages = new HashSet<PageTab>();
            PageTabPages = new HashSet<PageTab>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string PageLink { get; set; }
        public string PageHeading { get; set; }
        public Guid ModuleId { get; set; }
        public string TableOrViewName { get; set; }
        public string TableOrViewDisplayName { get; set; }
        public string ColumnToDisplay { get; set; }
        public Guid? HelpCardId { get; set; }
        public string UpdateStoredProcedure { get; set; }
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

        public virtual HelpCard HelpCard { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<PageGrid> PageGrids { get; set; }
        public virtual ICollection<PageQuickAdd> PageQuickAdds { get; set; }
        public virtual ICollection<PageTab> PageTabControlPages { get; set; }
        public virtual ICollection<PageTab> PageTabHeaderControlPages { get; set; }
        public virtual ICollection<PageTab> PageTabPages { get; set; }
    }
}
