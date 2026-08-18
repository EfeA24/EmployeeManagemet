using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Attendance
{
    public class CreateAttendancePunchDto
    {
        public Guid CompanyId { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public AttendancePunchType Type { get; set; }
    }
}