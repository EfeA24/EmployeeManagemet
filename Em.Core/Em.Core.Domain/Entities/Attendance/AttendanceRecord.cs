using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Attendance
{
    public class AttendanceRecord : TenantEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public DateOnly WorkDate { get; set; }

        public DateTime? CheckInAt { get; set; }
        public DateTime? CheckOutAt { get; set; }

        public int WorkedMinutes { get; set; }

        public AttendanceStatus Status { get; set; }

        public bool IsWeekend { get; set; }
        public bool IsPublicHoliday { get; set; }

        public string? Note { get; set; }

        public ICollection<AttendanceViolation> Violations { get; set; }
            = new List<AttendanceViolation>();

        public ICollection<AttendancePunch> Punches { get; set; }
            = new List<AttendancePunch>();

        public ICollection<AttendanceCorrection> Corrections { get; set; }
            = new List<AttendanceCorrection>();
    }
}
