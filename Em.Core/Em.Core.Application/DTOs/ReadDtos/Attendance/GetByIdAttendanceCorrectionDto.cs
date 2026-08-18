using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Attendance
{
    public class GetByIdAttendanceCorrectionDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public Guid CorrectedByEmployeeId { get; set; }
        public string CorrectedByEmployeeName { get; set; } = null!;
        public string FieldName { get; set; } = null!;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string Reason { get; set; } = null!;
        public DateTime CorrectedAt { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}