using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Attendance
{
    public class CreateAttendanceCorrectionDto
    {
        public Guid CompanyId { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public Guid CorrectedByEmployeeId { get; set; }
        public string FieldName { get; set; } = null!;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string Reason { get; set; } = null!;
    }
}