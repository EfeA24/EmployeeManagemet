using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Attendance
{
    public class CreateAttendancePolicyDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public TimeOnly ExpectedStartTime { get; set; }
        public TimeOnly ExpectedEndTime { get; set; }
        public int GracePeriodMinutes { get; set; }
        public int MinimumDailyWorkMinutes { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid? DepartmentId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}