using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class UserAccountTabList
    {
        public Guid UserAccountId { get; set; }
        public Guid PageId { get; set; }
        public Guid PageTabId { get; set; }
        public Guid ControlPageId { get; set; }
        public string PageTabName { get; set; }
        public int SortOrder { get; set; }
        public Guid? ModuleId { get; set; }
        public Guid? HeaderControlPageId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
