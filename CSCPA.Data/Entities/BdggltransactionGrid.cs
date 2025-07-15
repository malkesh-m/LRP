using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdggltransactionGrid
    {
        public Guid ObjectUid { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionAccount { get; set; }
        public decimal? TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
        public Guid BdgcompanyId { get; set; }
    }
}
