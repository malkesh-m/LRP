using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecdistributionDetail
    {
        public Guid FecdistributionId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string VoucherNo { get; set; }
        public Guid? ElectionCodeId { get; set; }
        public Guid? FecelectionTypeId { get; set; }
        public string ElectionOtherDescription { get; set; }
        public int? YearOfElection { get; set; }
        public string ExpenditurePurpose { get; set; }
        public decimal? ExpenditureAmount { get; set; }
        public Guid? FecBdgdepartmentId { get; set; }
        public Guid? FecBdgaccountGroupId { get; set; }
        public Guid? FecBdgaccountGroupSubGroupId { get; set; }
        public Guid? FecBdgaccountGroupSubGroupSubGroupId { get; set; }
        public Guid? FecBdgaccountGroupSubGroupSubGroupSubGroupId { get; set; }
        public Guid? FecBdggltransactionId { get; set; }
        public string AccountNumber { get; set; }
        public Guid? FecexpenseCategoryId { get; set; }
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
        public bool UseTax { get; set; }
        public Guid? FecLrpcodeId { get; set; }

        public virtual BdgaccountGroup FecBdgaccountGroup { get; set; }
        public virtual BdgaccountGroupSubGroup FecBdgaccountGroupSubGroup { get; set; }
        public virtual BdgaccountGroupSubGroupSubGroup FecBdgaccountGroupSubGroupSubGroup { get; set; }
        public virtual BdgaccountGroupSubGroupSubGroupSubGroup FecBdgaccountGroupSubGroupSubGroupSubGroup { get; set; }
        public virtual Bdgdepartment FecBdgdepartment { get; set; }
        public virtual Bdggltransaction FecBdggltransaction { get; set; }
        public virtual Lrpcode FecLrpcode { get; set; }
        public virtual Fecdistribution Fecdistribution { get; set; }
        public virtual FecelectionType FecelectionType { get; set; }
        public virtual FecexpenseCategory FecexpenseCategory { get; set; }
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
    }
}
