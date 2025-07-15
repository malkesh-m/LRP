using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class DynamicCode
    {
        public DynamicCode()
        {
            EventTriggers = new HashSet<EventTrigger>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Args1 { get; set; }
        public string Args2 { get; set; }
        public string Args3 { get; set; }
        public string Args4 { get; set; }
        public string Args5 { get; set; }
        public string ArgsName1 { get; set; }
        public string ArgsName2 { get; set; }
        public string ArgsName3 { get; set; }
        public string ArgsName4 { get; set; }
        public string ArgsName5 { get; set; }
        public string Language { get; set; }
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

        public virtual ICollection<EventTrigger> EventTriggers { get; set; }
    }
}
