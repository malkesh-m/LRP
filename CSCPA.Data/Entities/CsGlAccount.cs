using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsGlAccount
    {
        public string AccountKey { get; set; }
        public string AccountDesc { get; set; }
        public string Account { get; set; }
        public string RawAccount { get; set; }
        public string MainAccountCode { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Status { get; set; }
        public string ClearBalance { get; set; }
        public string AccountType { get; set; }
        public string CashFlowsType { get; set; }
        public string RollupCode1 { get; set; }
        public string RollupCode2 { get; set; }
        public string RollupCode3 { get; set; }
        public string RollupCode4 { get; set; }
        public string AccountGroup { get; set; }
        public string AccountCategory { get; set; }
        public string CompanyCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public string TimeCreated { get; set; }
        public string UserCreatedKey { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string TimeUpdated { get; set; }
        public string UserUpdatedKey { get; set; }
    }
}
