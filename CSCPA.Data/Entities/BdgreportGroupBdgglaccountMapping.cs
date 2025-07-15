using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgreportGroupBdgglaccountMapping
    {
        public Guid BdgreportGroupId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string AccountNo { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public Guid? BdgaccountGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupSubGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupSubGroupSubGroupId { get; set; }
        public string MaskedAccountNo { get; set; }
        public bool DoNotShowInReport { get; set; }
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

        public virtual BdgaccountGroup BdgaccountGroup { get; set; }
        public virtual BdgaccountGroupSubGroup BdgaccountGroupSubGroup { get; set; }
        public virtual BdgaccountGroupSubGroupSubGroup BdgaccountGroupSubGroupSubGroup { get; set; }
        public virtual BdgaccountGroupSubGroupSubGroupSubGroup BdgaccountGroupSubGroupSubGroupSubGroup { get; set; }
        public virtual Bdgdepartment Bdgdepartment { get; set; }
        public virtual BdgreportGroup BdgreportGroup { get; set; }
    }
}
