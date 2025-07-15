using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Fecdistribution
    {
        public Fecdistribution()
        {
            FecdistributionDetails = new HashSet<FecdistributionDetail>();
        }

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
        public decimal? DocumentAmount { get; set; }
        public Guid? FecLrpten99BoxNoId { get; set; }
        public Guid? FecLrpten99TaxTypeId { get; set; }
        public Guid? FecBdgaccountGroupId { get; set; }

        public virtual CountryState CandidateOrCommitteeCountryState { get; set; }
        public virtual CountryState ElectionCountryState { get; set; }
        public virtual BdgaccountGroup FecBdgaccountGroup { get; set; }
        public virtual Bdgdepartment FecBdgdepartment { get; set; }
        public virtual Lrpten99BoxNo FecLrpten99BoxNo { get; set; }
        public virtual Lrpten99TaxType FecLrpten99TaxType { get; set; }
        public virtual UserAccount FecUserAccount { get; set; }
        public virtual FecbatchStatus FecbatchStatus { get; set; }
        public virtual Feccandidate Feccandidate { get; set; }
        public virtual Feccommittee Feccommittee { get; set; }
        public virtual Feccompany Feccompany { get; set; }
        public virtual FecdisbursementType FecdisbursementType { get; set; }
        public virtual FecdistributionStatus FecdistributionStatus { get; set; }
        public virtual FecdistributionType FecdistributionType { get; set; }
        public virtual FecelectionOffice FecelectionOffice { get; set; }
        public virtual FecelectionType FecelectionType { get; set; }
        public virtual FecexpenseCategory FecexpenseCategory { get; set; }
        public virtual Fecvendor Fecvendor { get; set; }
        public virtual CountryState MailingCountryState { get; set; }
        public virtual CountryState VendorCountryState { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetails { get; set; }
    }
}
