using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpemployeeGrid
    {
        public Guid ObjectUid { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public DateTime TermDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string CostCenter { get; set; }
        public string EmployeeType { get; set; }
        public bool GrantWorker { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string EmployeeStatus { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string EmployeeNo { get; set; }
    }
}
