using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Attendance
{
    public class GetByIdAttendancePunchDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public AttendancePunchType Type { get; set; }
        public DateTime PunchedAt { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}