using System;
using System.ComponentModel.DataAnnotations;

namespace CSCPA.Model
{
    public class LRPTimeEntryListModel
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }

        [Display(Name ="Code")]
        public Guid? LrpcodeId { get; set; }

        [Display(Name = "Employee")]
        public Guid? LrpemployeeId { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? LrpDateStart { get; set; }

        [Display(Name = "End Date")]
        public DateTime? LrpDateEnd { get; set; }
        public decimal? Percentage { get; set; }
        public string Description { get; set; }
    }
    public class LRPTimeEntryAddEditModel
    {
        public Guid? ObjectUid { get; set; }
        public string Name { get; set; }
        public Guid? LrpcodeId { get; set; }
        public Guid? LrpemployeeId { get; set; }
        public DateTime? LrpDateStart { get; set; }
        public DateTime? LrpDateEnd { get; set; }
        public decimal? Percentage { get; set; }
        public string Description { get; set; }
    }
}
