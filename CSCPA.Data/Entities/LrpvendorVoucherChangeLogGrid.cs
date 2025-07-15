using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorVoucherChangeLogGrid
    {
        public Guid ObjectUid { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string TrxDescription { get; set; }
        public decimal? _1099Amount { get; set; }
        public string CssLink { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int RecordId { get; set; }
        public DateTime? InvoiceDateOld { get; set; }
        public string TrxDescriptionOld { get; set; }
        public decimal? _1099AmountOld { get; set; }
        public string _1099BoxNo { get; set; }
        public string _1099TaxType { get; set; }
        public string _1099BoxNoOld { get; set; }
        public string _1099TaxTypeOld { get; set; }
    }
}
