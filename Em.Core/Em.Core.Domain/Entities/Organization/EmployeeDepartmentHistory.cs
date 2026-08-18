using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Organization
{
    public class EmployeeDepartmentHistory : TenantEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public string? ChangeNote { get; set; }
    }
}
