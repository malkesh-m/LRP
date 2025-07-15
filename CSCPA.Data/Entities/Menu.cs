using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            InverseParentMenu = new HashSet<Menu>();
            MenuParameterTypes = new HashSet<MenuParameterType>();
            UserAccounts = new HashSet<UserAccount>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string MenuLink { get; set; }
        public string MenuIconLink { get; set; }
        public Guid? ModuleId { get; set; }
        public bool ShowToAll { get; set; }
        public bool IsParent { get; set; }
        public Guid? ParentMenuId { get; set; }
        public Guid PortalId { get; set; }
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
        public bool IsSeparator { get; set; }

        public virtual Module Module { get; set; }
        public virtual Menu ParentMenu { get; set; }
        public virtual Portal Portal { get; set; }
        public virtual ICollection<Menu> InverseParentMenu { get; set; }
        public virtual ICollection<MenuParameterType> MenuParameterTypes { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
