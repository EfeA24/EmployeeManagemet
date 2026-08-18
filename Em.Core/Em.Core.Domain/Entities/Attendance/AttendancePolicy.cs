using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Attendance
{
    public class AttendancePolicy : TenantEntity
    {
        public string Name { get; set; } = null!;

        public TimeOnly ExpectedStartTime { get; set; }
        public TimeOnly ExpectedEndTime { get; set; }

        public int GracePeriodMinutes { get; set; }
        public int MinimumDailyWorkMinutes { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
