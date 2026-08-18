using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Organization
{
    public class CompanySetting : TenantEntity
    {
        public int TicketExpirationDays { get; set; } = 30;
        public int TicketExpiryReminderDays { get; set; } = 3;

        public bool AllowPastDateLeaveRequests { get; set; }
        public bool CountWeekendsAsLeaveDays { get; set; }
        public bool CountPublicHolidaysAsLeaveDays { get; set; }
        public int DefaultAnnualLeaveDays { get; set; }

        public bool SaturdayIsWeekend { get; set; } = true;
        public bool SundayIsWeekend { get; set; } = true;

        public bool AllowMultipleAttendancePunchesPerDay { get; set; }

        public int AssetReturnReminderDays { get; set; } = 3;
    }
}
