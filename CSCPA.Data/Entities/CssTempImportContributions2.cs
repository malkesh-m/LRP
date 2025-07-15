using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssTempImportContributions2
    {
        public double? ContributionId { get; set; }
        public string LocalStateFedNumber { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? DepositDate { get; set; }
        public string CheckNumber { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal? Amount { get; set; }
        public string ElectionCycle { get; set; }
        public string ElectionQuarter { get; set; }
        public decimal? ObjectUid { get; set; }
        public decimal? Display { get; set; }
        public double? Name { get; set; }
        public string NameAlias { get; set; }
        public string FeccompanyId { get; set; }
        public string FeclocalUnionId { get; set; }
        public DateTime? StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal? MemberTotal { get; set; }
        public string FeccontributionTypeId { get; set; }
        public string CheckNo { get; set; }
        public DateTime? CheckDate1 { get; set; }
        public string GpreferenceNo { get; set; }
        public DateTime? DepositDate1 { get; set; }
        public string FeccontributionStatusId { get; set; }
        public string UploadDetail { get; set; }
        public string FeccashAccountId { get; set; }
        public string DateReceived { get; set; }
        public string FeccontributionSourceId { get; set; }
        public string Description { get; set; }
    }
}
