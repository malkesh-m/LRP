using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecdistributionDetailGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid FecdistributionId { get; set; }
        public string InvoiceNo { get; set; }
        public string ElectionType { get; set; }
        public string ElectionOtherDescription { get; set; }
        public int? YearOfElection { get; set; }
        public string ExpenditurePurpose { get; set; }
        public decimal? ExpenditureAmount { get; set; }
        public string ExpenseCategory { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string AccountGroup { get; set; }
        public string SubSubSubGroup { get; set; }
        public string Department { get; set; }
        public string SubSubGroup { get; set; }
        public string SubGroup { get; set; }
    }
}
