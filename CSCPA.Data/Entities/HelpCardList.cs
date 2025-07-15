using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class HelpCardList
    {
        public Guid PageId { get; set; }
        public string PageLink { get; set; }
        public Guid? HelpCardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
