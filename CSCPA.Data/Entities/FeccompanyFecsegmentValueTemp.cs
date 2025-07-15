using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FeccompanyFecsegmentValueTemp
    {
        public string Statusid { get; set; }
        public Guid FeccompanyId { get; set; }
        public Guid FeccompanyFecsegmentId { get; set; }
        public Guid FecsegmentId { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int IsDeleted { get; set; }
        public int IsInactive { get; set; }
        public int IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
