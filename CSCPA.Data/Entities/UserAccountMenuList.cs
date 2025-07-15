using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class UserAccountMenuList
    {
        public Guid? ModuleId { get; set; }
        public Guid? UserAccountId { get; set; }
        public Guid MenuId { get; set; }
        public string Display { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public string MenuIconLink { get; set; }
        public int SortOrder { get; set; }
        public bool IsParent { get; set; }
        public Guid? ParentMenuId { get; set; }
        public bool ShowToAll { get; set; }
        public bool IsSeparator { get; set; }
        public string Portal { get; set; }
    }
}
