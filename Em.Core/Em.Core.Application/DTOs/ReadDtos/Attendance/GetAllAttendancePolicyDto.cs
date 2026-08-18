using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Attendance
{
    public class GetAllAttendancePolicyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public TimeOnly ExpectedStartTime { get; set; }
        public TimeOnly ExpectedEndTime { get; set; }
        public int GracePeriodMinutes { get; set; }
        public bool IsActive { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}