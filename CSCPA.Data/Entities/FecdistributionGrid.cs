using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecdistributionGrid
    {
        public Guid ObjectUid { get; set; }
        public string Company { get; set; }
        public string VoucherNo { get; set; }
        public string DisbursementType { get; set; }
        public string DistributionStatus { get; set; }
        public string ElectionType { get; set; }
        public int? YearOfElection { get; set; }
        public string ElectionOtherDescription { get; set; }
        public string ExpenseCategory { get; set; }
        public string DistributionType { get; set; }
        public string Candidate { get; set; }
        public string Vendor { get; set; }
        public string Committee { get; set; }
        public string Idno { get; set; }
        public string VendorName { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string BatchNo { get; set; }
        public string CheckNo { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal? CheckAmount { get; set; }
        public string AccountIdentifier { get; set; }
        public string MailingAddressI { get; set; }
        public string MailingAddressIi { get; set; }
        public string MailingCity { get; set; }
        public string MailingCountryState { get; set; }
        public string MailingPostalCode { get; set; }
        public string MailingPhone { get; set; }
        public string MailingFax { get; set; }
        public string MailingEmail { get; set; }
        public string VendorAddressI { get; set; }
        public string VendorAddressIi { get; set; }
        public string VendorCity { get; set; }
        public string VendorCountryState { get; set; }
        public string VendorPostalCode { get; set; }
        public string VendorPhone { get; set; }
        public string VendorFax { get; set; }
        public string VendorEmail { get; set; }
        public string CandidateOrCommitteeAddressI { get; set; }
        public string CandidateOrCommitteeAddressIi { get; set; }
        public string CandidateOrCommitteeCity { get; set; }
        public string CandidateOrCommitteeCountryState { get; set; }
        public string CandidateOrCommitteePostalCode { get; set; }
        public string CandidateOrCommitteePhone { get; set; }
        public string CandidateOrCommitteeFax { get; set; }
        public string CandidateOrCommitteeEmail { get; set; }
        public string ElectionOffice { get; set; }
        public string ElectionCountryState { get; set; }
        public string ElectionDistrict { get; set; }
        public string ElectionOtherIdentification { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid FeccompanyId { get; set; }
        public Guid? FecBdgdepartmentId { get; set; }
        public Guid? FecUserAccountId { get; set; }
        public decimal? AmountToBePaid { get; set; }
        public decimal? ControlAmount { get; set; }
    }
}
