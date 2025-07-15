using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssContributionPlusDeatil
    {
        public Guid AObjectUid { get; set; }
        public string ADisplay { get; set; }
        public string AName { get; set; }
        public string ANameAlias { get; set; }
        public Guid AFeccompanyId { get; set; }
        public Guid? AFeclocalUnionId { get; set; }
        public DateTime? AStartDate { get; set; }
        public DateTime? AEndDate { get; set; }
        public decimal? ADepositAmount { get; set; }
        public decimal? AMemberTotal { get; set; }
        public Guid? AFeccontributionTypeId { get; set; }
        public string ACheckNo { get; set; }
        public DateTime? ACheckDate { get; set; }
        public string AGpreferenceNo { get; set; }
        public DateTime? ADepositDate { get; set; }
        public Guid? AFeccontributionStatusId { get; set; }
        public byte[] AUploadDetail { get; set; }
        public Guid? AFeccashAccountId { get; set; }
        public DateTime? ADateReceived { get; set; }
        public Guid? AFeccontributionSourceId { get; set; }
        public string ADescription { get; set; }
        public int ASortOrder { get; set; }
        public bool AIsDeleted { get; set; }
        public bool AIsInactive { get; set; }
        public bool AIsLocked { get; set; }
        public DateTime ACreatedOn { get; set; }
        public string ACreatedBy { get; set; }
        public DateTime? AUpdatedOn { get; set; }
        public string AUpdatedBy { get; set; }
        public int ARecordId { get; set; }
        public int? AOldRecordId { get; set; }
        public Guid? AInstallationUid { get; set; }
        public string AImportedObjectUid { get; set; }
        public Guid BFeccontributionId { get; set; }
        public Guid BObjectUid { get; set; }
        public string BDisplay { get; set; }
        public string BName { get; set; }
        public string BNameAlias { get; set; }
        public Guid? BFecmemberId { get; set; }
        public string BMemberCode { get; set; }
        public Guid? BFeclocalUnionId { get; set; }
        public string BFirstName { get; set; }
        public string BMiddleName { get; set; }
        public string BLastName { get; set; }
        public string BPrefix { get; set; }
        public string BPhoneHome { get; set; }
        public string BEmailPrimary { get; set; }
        public string BAddressLineI { get; set; }
        public string BAddressLineIi { get; set; }
        public string BCity { get; set; }
        public Guid? BCountryStateId { get; set; }
        public string BPostalCode { get; set; }
        public string BJobTitle { get; set; }
        public string BEmployer { get; set; }
        public decimal? BContributionAmount { get; set; }
        public string BDescription { get; set; }
        public int BSortOrder { get; set; }
        public bool BIsDeleted { get; set; }
        public bool BIsInactive { get; set; }
        public bool BIsLocked { get; set; }
        public DateTime BCreatedOn { get; set; }
        public string BCreatedBy { get; set; }
        public DateTime? BUpdatedOn { get; set; }
        public string BUpdatedBy { get; set; }
        public int BRecordId { get; set; }
        public int? BOldRecordId { get; set; }
        public Guid? BInstallationUid { get; set; }
        public string BImportedObjectUid { get; set; }
        public string FeclocalUnionName { get; set; }
        public string FeccontributionStatusName { get; set; }
        public string FeccontributionSourceName { get; set; }
        public string FeccontributionTypeName { get; set; }
        public string FeccashAccountName { get; set; }
        public string FecmemberName { get; set; }
        public string FeccompanyName { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string GlaccountNumber { get; set; }
        public string GpaccountName { get; set; }
        public string GpcheckBook { get; set; }
        public string Number { get; set; }
        public string State { get; set; }
    }
}
