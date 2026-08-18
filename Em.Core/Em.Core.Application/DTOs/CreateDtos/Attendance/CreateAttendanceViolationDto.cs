using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Attendance
{
    public class CreateAttendanceViolationDto
    {
        public Guid CompanyId { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public AttendanceViolationType Type { get; set; }
        public int? DifferenceMinutes { get; set; }
        public string Message { get; set; } = null!;
    }
}