using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Attendance
{
    public class AttendanceCorrection : TenantEntity
    {
        public Guid AttendanceRecordId { get; set; }
        public AttendanceRecord AttendanceRecord { get; set; } = null!;

        public Guid CorrectedByEmployeeId { get; set; }
        public Employee CorrectedByEmployee { get; set; } = null!;

        public string FieldName { get; set; } = null!;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }

        public string Reason { get; set; } = null!;
        public DateTime CorrectedAt { get; set; }
    }
}
