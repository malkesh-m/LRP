using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecexpenseCategoryFecsegmentValueGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid FecexpenseCategoryId { get; set; }
        public string Segment { get; set; }
        public string Value { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid FeccompanyFecsegmentId { get; set; }
        public Guid? FecsegmentId { get; set; }
        public Guid FeccompanyFecsegmentValueId { get; set; }
    }
}
