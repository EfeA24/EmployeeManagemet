using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Attendance
{
    public class AttendanceViolation : TenantEntity
    {
        public Guid AttendanceRecordId { get; set; }
        public AttendanceRecord AttendanceRecord { get; set; } = null!;

        public AttendanceViolationType Type { get; set; }

        public int? DifferenceMinutes { get; set; }

        public string Message { get; set; } = null!;

        public bool IsAcknowledged { get; set; }
        public DateTime? AcknowledgedAt { get; set; }

        public string? ExcuseNote { get; set; }
        public bool IsExcuseAccepted { get; set; }

        public string? ReviewNote { get; set; }
        public Guid? ReviewedByEmployeeId { get; set; }
        public Employee? ReviewedByEmployee { get; set; }
    }
}
