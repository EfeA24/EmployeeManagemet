using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Attendance
{
    public class GetAllAttendancePunchDto
    {
        public Guid Id { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public AttendancePunchType Type { get; set; }
        public DateTime PunchedAt { get; set; }
    }
}