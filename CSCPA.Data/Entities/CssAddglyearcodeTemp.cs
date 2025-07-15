using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssAddglyearcodeTemp
    {
        public string Test { get; set; }
        public string Name { get; set; }
        public string Namealias { get; set; }
        public Guid Yearsetupid { get; set; }
        public Guid Codeid { get; set; }
        public int ItemizedAmount { get; set; }
        public int NonItemizedAmount { get; set; }
        public int TotalAmount { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int IsDeleted { get; set; }
        public int IsInactive { get; set; }
        public int IsLocked { get; set; }
        public DateTime Createdon { get; set; }
        public string Createdby { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int OldRecordId { get; set; }
        public string ImportedObjectUid { get; set; }
    }
}
