using System;
using System.ComponentModel.DataAnnotations;

namespace CSCPA.Model
{
    public class LRPDepartmentListModel
    {
        public Guid ObjectUID { get; set; }

        [Display(Name = "Department No")]
        public string DepartmentNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class LRPDepartmentAddEditModel
    {
        public Guid? ObjectUID { get; set; }

        [Display(Name = "Department Number")]
        public string DepartmentNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}