using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class TempTableList
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
        public int? LobDataSpaceId { get; set; }
        public int? FilestreamDataSpaceId { get; set; }
        public int? MaxColumnIdUsed { get; set; }
        public bool? LockOnBulkLoad { get; set; }
        public bool? UsesAnsiNulls { get; set; }
        public bool? IsReplicated { get; set; }
        public bool? HasReplicationFilter { get; set; }
        public bool? IsMergePublished { get; set; }
        public bool? IsSyncTranSubscribed { get; set; }
        public bool? HasUncheckedAssemblyData { get; set; }
        public int? TextInRowLimit { get; set; }
        public bool? LargeValueTypesOutOfRow { get; set; }
        public bool? IsTrackedByCdc { get; set; }
        public byte? LockEscalation { get; set; }
        public string LockEscalationDesc { get; set; }
    }
}
