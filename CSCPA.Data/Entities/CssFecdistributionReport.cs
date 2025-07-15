using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssFecdistributionReport
    {
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid FeccompanyId { get; set; }
        public Guid? FecbatchStatusId { get; set; }
        public string VoucherNo { get; set; }
        public Guid? FecBdgdepartmentId { get; set; }
        public Guid? FecUserAccountId { get; set; }
        public Guid? FecdisbursementTypeId { get; set; }
        public Guid? FecdistributionStatusId { get; set; }
        public Guid? FecelectionTypeId { get; set; }
        public int? YearOfElection { get; set; }
        public string ElectionOtherDescription { get; set; }
        public Guid? FecexpenseCategoryId { get; set; }
        public Guid? FecdistributionTypeId { get; set; }
        public Guid? FeccandidateId { get; set; }
        public Guid? FecvendorId { get; set; }
        public Guid? FeccommitteeId { get; set; }
        public string Idno { get; set; }
        public string VendorName { get; set; }
        public DateTime? DistributionDate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocumentNo { get; set; }
        public decimal? ControlAmount { get; set; }
        public decimal? AmountRemaining { get; set; }
        public string BatchNo { get; set; }
        public string CheckNo { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal? CheckAmount { get; set; }
        public string AccountIdentifier { get; set; }
        public string MailingAddressI { get; set; }
        public string MailingAddressIi { get; set; }
        public string MailingCity { get; set; }
        public Guid? MailingCountryStateId { get; set; }
        public string MailingPostalCode { get; set; }
        public string MailingPhone { get; set; }
        public string MailingFax { get; set; }
        public string MailingEmail { get; set; }
        public string VendorAddressI { get; set; }
        public string VendorAddressIi { get; set; }
        public string VendorCity { get; set; }
        public Guid? VendorCountryStateId { get; set; }
        public string VendorPostalCode { get; set; }
        public string VendorPhone { get; set; }
        public string VendorFax { get; set; }
        public string VendorEmail { get; set; }
        public string CandidateOrCommitteeAddressI { get; set; }
        public string CandidateOrCommitteeAddressIi { get; set; }
        public string CandidateOrCommitteeCity { get; set; }
        public Guid? CandidateOrCommitteeCountryStateId { get; set; }
        public string CandidateOrCommitteePostalCode { get; set; }
        public string CandidateOrCommitteePhone { get; set; }
        public string CandidateOrCommitteeFax { get; set; }
        public string CandidateOrCommitteeEmail { get; set; }
        public Guid? FecelectionOfficeId { get; set; }
        public Guid? ElectionCountryStateId { get; set; }
        public string ElectionDistrict { get; set; }
        public string ElectionOtherIdentification { get; set; }
        public string HeaderDescription { get; set; }
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
        public string AccountNumber { get; set; }
        public string LineNotes { get; set; }
        public decimal? ExpenditureAmount { get; set; }
        public string ExpenditurePurpose { get; set; }
        public string ApprovedValue { get; set; }
        public string Companyname { get; set; }
        public string Bdgdepartmentname { get; set; }
        public string Bdgdepartmentnameline { get; set; }
        public string Bdgaccountgroupname { get; set; }
        public Guid FecdistibutionlineObjectuid { get; set; }
        public decimal? DocumentAmount { get; set; }
        public string BdgaccountGroupName2 { get; set; }
        public string Lrpten99BoxNoName { get; set; }
        public string Lrpten99TaxTypeName { get; set; }
        public bool UseTax { get; set; }
        public string LrpcodeName { get; set; }
    }
}
