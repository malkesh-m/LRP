using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class PageGrid1
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string PageLink { get; set; }
        public string PageHeading { get; set; }
        public string Module { get; set; }
        public string TableOrViewName { get; set; }
        public string TableOrViewDisplayName { get; set; }
        public string ColumnToDisplay { get; set; }
        public string HelpCard { get; set; }
        public string UpdateStoredProcedure { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
