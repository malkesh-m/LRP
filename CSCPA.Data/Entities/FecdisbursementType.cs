using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecdisbursementType
    {
        public FecdisbursementType()
        {
            FecdisbursementTypeFecdistributionTypes = new HashSet<FecdisbursementTypeFecdistributionType>();
            Fecdistributions = new HashSet<Fecdistribution>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid FeccompanyId { get; set; }
        public Guid? Segment1FeccompanyFecsegmentValueId { get; set; }
        public Guid? Segment2FeccompanyFecsegmentValueId { get; set; }
        public Guid? Segment3FeccompanyFecsegmentValueId { get; set; }
        public Guid? Segment4FeccompanyFecsegmentValueId { get; set; }
        public Guid? Segment5FeccompanyFecsegmentValueId { get; set; }
        public Guid? Segment6FeccompanyFecsegmentValueId { get; set; }
        public Guid? Segment7FeccompanyFecsegmentValueId { get; set; }
        public Guid? Segment8FeccompanyFecsegmentValueId { get; set; }
        public Guid? Segment9FeccompanyFecsegmentValueId { get; set; }
        public Guid? Segment10FeccompanyFecsegmentValueId { get; set; }
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
        public bool IsFec { get; set; }

        public virtual Feccompany Feccompany { get; set; }
        public virtual FeccompanyFecsegmentValue Segment10FeccompanyFecsegmentValue { get; set; }
        public virtual FeccompanyFecsegmentValue Segment1FeccompanyFecsegmentValue { get; set; }
        public virtual FeccompanyFecsegmentValue Segment2FeccompanyFecsegmentValue { get; set; }
        public virtual FeccompanyFecsegmentValue Segment3FeccompanyFecsegmentValue { get; set; }
        public virtual FeccompanyFecsegmentValue Segment4FeccompanyFecsegmentValue { get; set; }
        public virtual FeccompanyFecsegmentValue Segment5FeccompanyFecsegmentValue { get; set; }
        public virtual FeccompanyFecsegmentValue Segment6FeccompanyFecsegmentValue { get; set; }
        public virtual FeccompanyFecsegmentValue Segment7FeccompanyFecsegmentValue { get; set; }
        public virtual FeccompanyFecsegmentValue Segment8FeccompanyFecsegmentValue { get; set; }
        public virtual FeccompanyFecsegmentValue Segment9FeccompanyFecsegmentValue { get; set; }
        public virtual ICollection<FecdisbursementTypeFecdistributionType> FecdisbursementTypeFecdistributionTypes { get; set; }
        public virtual ICollection<Fecdistribution> Fecdistributions { get; set; }
    }
}
