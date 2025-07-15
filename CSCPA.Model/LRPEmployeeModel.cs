using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class LRPEmployeeListModel
    {
        public Guid ObjectUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string EmployeeNo { get; set; }
        public Guid LrpdepartmentId { get; set; }
        public string JobTitle { get; set; }
        public DateTime? TermDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Guid? LrpcostCenterId { get; set; }
        public Guid? LrpemployeeTypeId { get; set; }
        public bool GrantWorker { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public Guid? LrpemployeeStatusId { get; set; }
        public string Description { get; set; }
        public bool IsInactive { get; set; }

    }
    public class LRPEmployeeAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string EmployeeNo { get; set; }
        public Guid LrpdepartmentId { get; set; }
        public string JobTitle { get; set; }
        public DateTime? TermDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Guid? LrpcostCenterId { get; set; }
        public Guid? LrpemployeeTypeId { get; set; }
        public bool GrantWorker { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public Guid? LrpemployeeStatusId { get; set; }
        public string Description { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
