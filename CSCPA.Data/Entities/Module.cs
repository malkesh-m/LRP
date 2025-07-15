using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Module
    {
        public Module()
        {
            ApplicationLogs = new HashSet<ApplicationLog>();
            DynamicFields = new HashSet<DynamicField>();
            Menus = new HashSet<Menu>();
            PageTabs = new HashSet<PageTab>();
            Pages = new HashSet<Page>();
            ReferenceAttachments = new HashSet<ReferenceAttachment>();
            ReferenceNotes = new HashSet<ReferenceNote>();
            ReferenceUserAccounts = new HashSet<ReferenceUserAccount>();
            ResourceTranslations = new HashSet<ResourceTranslation>();
            RoleModules = new HashSet<RoleModule>();
            UserAccountModules = new HashSet<UserAccountModule>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid? HelpCardId { get; set; }
        public bool IsPrimaryEntity { get; set; }
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
        public virtual ICollection<ApplicationLog> ApplicationLogs { get; set; }
        public virtual ICollection<DynamicField> DynamicFields { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<PageTab> PageTabs { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<ReferenceAttachment> ReferenceAttachments { get; set; }
        public virtual ICollection<ReferenceNote> ReferenceNotes { get; set; }
        public virtual ICollection<ReferenceUserAccount> ReferenceUserAccounts { get; set; }
        public virtual ICollection<ResourceTranslation> ResourceTranslations { get; set; }
        public virtual ICollection<RoleModule> RoleModules { get; set; }
        public virtual ICollection<UserAccountModule> UserAccountModules { get; set; }
    }
}
