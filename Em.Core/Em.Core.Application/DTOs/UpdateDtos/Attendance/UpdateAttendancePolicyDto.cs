using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.UpdateDtos.Attendance
{
    public class UpdateAttendancePolicyDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public TimeOnly ExpectedStartTime { get; set; }
        public TimeOnly ExpectedEndTime { get; set; }
        public int GracePeriodMinutes { get; set; }
        public int MinimumDailyWorkMinutes { get; set; }
        public bool IsActive { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}