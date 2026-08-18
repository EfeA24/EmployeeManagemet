using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Attendance
{
    public class GetByIdAttendancePolicyDto
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
        public string? DepartmentName { get; set; }
        public Guid? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}