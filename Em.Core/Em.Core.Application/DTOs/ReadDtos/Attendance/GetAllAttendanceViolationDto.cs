using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Attendance
{
    public class GetAllAttendanceViolationDto
    {
        public Guid Id { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public AttendanceViolationType Type { get; set; }
        public string Message { get; set; } = null!;
        public bool IsAcknowledged { get; set; }
        public bool IsExcuseAccepted { get; set; }
    }
}