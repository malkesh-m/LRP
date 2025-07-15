using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class TempTriggersList
    {
        public string Source1 { get; set; }
        public DateTime? Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string Namevalue { get; set; }
        public string Name { get; set; }
        public int? ObjectId { get; set; }
        public byte? ParentClass { get; set; }
        public string ParentClassDesc { get; set; }
        public int? ParentId { get; set; }
        public string Type { get; set; }
        public string TypeDesc { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool? IsMsShipped { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsNotForReplication { get; set; }
        public bool? IsInsteadOfTrigger { get; set; }
    }
}
