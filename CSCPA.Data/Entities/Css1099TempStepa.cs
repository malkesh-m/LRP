using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Css1099TempStepa
    {
        public string VendorNo { get; set; }
        public decimal? Ten99amnt { get; set; }
        public Guid? Lrpten99BoxNoId { get; set; }
        public Guid? Lrpten99TaxTypeId { get; set; }
        public DateTime? Pstgdate { get; set; }
        public Guid LrpvendorVoucherid { get; set; }
        public Guid Lrpvendorid { get; set; }
        public string Name { get; set; }
        public DateTime? Paymentdate { get; set; }
        public string Voucherno { get; set; }
        public string Checkno { get; set; }
        public string Lrpcompanyname { get; set; }
        public string DocumentNo { get; set; }
        public decimal? DocumentAmount { get; set; }
        public string TrxDescription { get; set; }
        public string Company { get; set; }
    }
}
