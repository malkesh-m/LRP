using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FeccompanyFecsegmentValue
    {
        public FeccompanyFecsegmentValue()
        {
            FecdisbursementTypeSegment10FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdisbursementTypeSegment1FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdisbursementTypeSegment2FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdisbursementTypeSegment3FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdisbursementTypeSegment4FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdisbursementTypeSegment5FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdisbursementTypeSegment6FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdisbursementTypeSegment7FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdisbursementTypeSegment8FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdisbursementTypeSegment9FeccompanyFecsegmentValues = new HashSet<FecdisbursementType>();
            FecdistributionDetailSegment10FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecdistributionDetailSegment1FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecdistributionDetailSegment2FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecdistributionDetailSegment3FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecdistributionDetailSegment4FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecdistributionDetailSegment5FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecdistributionDetailSegment6FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecdistributionDetailSegment7FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecdistributionDetailSegment8FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecdistributionDetailSegment9FeccompanyFecsegmentValues = new HashSet<FecdistributionDetail>();
            FecexpenseCategoryFecsegmentValues = new HashSet<FecexpenseCategoryFecsegmentValue>();
            FecexpenseCategorySegment10FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
            FecexpenseCategorySegment1FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
            FecexpenseCategorySegment2FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
            FecexpenseCategorySegment3FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
            FecexpenseCategorySegment4FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
            FecexpenseCategorySegment5FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
            FecexpenseCategorySegment6FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
            FecexpenseCategorySegment7FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
            FecexpenseCategorySegment8FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
            FecexpenseCategorySegment9FeccompanyFecsegmentValues = new HashSet<FecexpenseCategory>();
        }

        public Guid FeccompanyId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public Guid FeccompanyFecsegmentId { get; set; }
        public Guid? FecsegmentId { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
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
        public string AdditionalInfo { get; set; }

        public virtual Feccompany Feccompany { get; set; }
        public virtual FeccompanyFecsegment FeccompanyFecsegment { get; set; }
        public virtual Fecsegment Fecsegment { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment10FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment1FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment2FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment3FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment4FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment5FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment6FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment7FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment8FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdisbursementType> FecdisbursementTypeSegment9FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment10FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment1FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment2FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment3FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment4FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment5FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment6FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment7FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment8FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetailSegment9FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategoryFecsegmentValue> FecexpenseCategoryFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment10FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment1FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment2FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment3FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment4FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment5FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment6FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment7FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment8FeccompanyFecsegmentValues { get; set; }
        public virtual ICollection<FecexpenseCategory> FecexpenseCategorySegment9FeccompanyFecsegmentValues { get; set; }
    }
}
