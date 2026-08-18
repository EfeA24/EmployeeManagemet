using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Attendance
{
    public class UpdateAttendanceViolationDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public AttendanceViolationType Type { get; set; }
        public int? DifferenceMinutes { get; set; }
        public string Message { get; set; } = null!;
        public bool IsAcknowledged { get; set; }
        public DateTime? AcknowledgedAt { get; set; }
        public string? ExcuseNote { get; set; }
        public bool IsExcuseAccepted { get; set; }
        public string? ReviewNote { get; set; }
        public Guid? ReviewedByEmployeeId { get; set; }
    }
}