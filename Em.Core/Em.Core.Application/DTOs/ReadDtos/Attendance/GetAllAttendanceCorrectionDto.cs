using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Attendance
{
    public class GetAllAttendanceCorrectionDto
    {
        public Guid Id { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public string FieldName { get; set; } = null!;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public Guid CorrectedByEmployeeId { get; set; }
        public string CorrectedByEmployeeName { get; set; } = null!;
        public DateTime CorrectedAt { get; set; }
    }
}