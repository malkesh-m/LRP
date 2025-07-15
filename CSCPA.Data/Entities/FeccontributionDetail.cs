using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FeccontributionDetail
    {
        public FeccontributionDetail()
        {
            InverseAdjustmentFeccontributionDetail = new HashSet<FeccontributionDetail>();
        }

        public Guid FeccontributionId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid? FecmemberId { get; set; }
        public string MemberCode { get; set; }
        public Guid? FeclocalUnionId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Prefix { get; set; }
        public string PhoneHome { get; set; }
        public string EmailPrimary { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string City { get; set; }
        public Guid? CountryStateId { get; set; }
        public string PostalCode { get; set; }
        public string JobTitle { get; set; }
        public string Employer { get; set; }
        public decimal? ContributionAmount { get; set; }
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
        public Guid? FecpaymentFrequencyId { get; set; }
        public decimal? PaymentAmount { get; set; }
        public Guid? AdjustmentFeccontributionDetailId { get; set; }

        public virtual FeccontributionDetail AdjustmentFeccontributionDetail { get; set; }
        public virtual CountryState CountryState { get; set; }
        public virtual Feccontribution Feccontribution { get; set; }
        public virtual FeclocalUnion FeclocalUnion { get; set; }
        public virtual Fecmember Fecmember { get; set; }
        public virtual FecpaymentFrequency FecpaymentFrequency { get; set; }
        public virtual ICollection<FeccontributionDetail> InverseAdjustmentFeccontributionDetail { get; set; }
    }
}
