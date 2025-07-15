using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class ReferenceAttachment
    {
        public ReferenceAttachment()
        {
            ReferenceAttachmentUserAccounts = new HashSet<ReferenceAttachmentUserAccount>();
        }

        public Guid ReferenceId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid? AttachmentId { get; set; }
        public byte[] Attachment { get; set; }
        public Guid? AttachmentTypeId { get; set; }
        public Guid? AttachmentToModuleId { get; set; }
        public string Location { get; set; }
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
        public string Source { get; set; }
        public Guid? PortalId { get; set; }

        public virtual Attachment AttachmentNavigation { get; set; }
        public virtual Module AttachmentToModule { get; set; }
        public virtual AttachmentType AttachmentType { get; set; }
        public virtual Portal Portal { get; set; }
        public virtual ICollection<ReferenceAttachmentUserAccount> ReferenceAttachmentUserAccounts { get; set; }
    }
}
