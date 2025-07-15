using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssAp1099Temp
    {
        public string _1099Type { get; set; }
        public string _1099Box { get; set; }
        public short? Ten99boxnumber { get; set; }
        public short? Ten99type { get; set; }
        public string _1099Flag { get; set; }
        public string VoucherNo { get; set; }
        public string FinalId { get; set; }
        public string Acct { get; set; }
        public string Descr { get; set; }
        public DateTime? Checkdate { get; set; }
        public string Checkno { get; set; }
        public DateTime? Trandate { get; set; }
        public string Description { get; set; }
        public double? Amount { get; set; }
        public string Vendname { get; set; }
        public string Txidnmbr { get; set; }
        public string CssLink { get; set; }
        public decimal? Ten99amnt { get; set; }
        public decimal? DocumentAmount { get; set; }
        public bool? Voided { get; set; }
        public decimal? Ten99amnttotal { get; set; }
        public short? Ten99boxnumber1 { get; set; }
        public short? Ten99type1 { get; set; }
        public short? Year1 { get; set; }
        public string IdField { get; set; }
        public string Refnbr { get; set; }
    }
}
