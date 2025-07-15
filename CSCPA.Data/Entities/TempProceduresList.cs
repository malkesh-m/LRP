using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class TempProceduresList
    {
        public string Source1 { get; set; }
        public DateTime? Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string Namevalue { get; set; }
        public string Name { get; set; }
        public int? ObjectId { get; set; }
        public int? PrincipalId { get; set; }
        public int? SchemaId { get; set; }
        public int? ParentObjectId { get; set; }
        public string Type { get; set; }
        public string TypeDesc { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool? IsMsShipped { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsSchemaPublished { get; set; }
        public bool? IsAutoExecuted { get; set; }
        public bool? IsExecutionReplicated { get; set; }
        public bool? IsReplSerializableOnly { get; set; }
        public bool? SkipsReplConstraints { get; set; }
    }
}
