using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Attendance
{
    public class AttendanceViolation : BaseEntity
    {
        public Guid AttendanceRecordId { get; set; }
        public AttendanceRecord AttendanceRecord { get; set; } = null!;

        public AttendanceViolationType Type { get; set; }

        public int? DifferenceMinutes { get; set; }

        public string Message { get; set; } = null!;

        public bool IsAcknowledged { get; set; }
        public DateTime? AcknowledgedAt { get; set; }
    }
}
