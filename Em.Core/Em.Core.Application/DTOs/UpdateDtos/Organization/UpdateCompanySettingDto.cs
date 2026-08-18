using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.UpdateDtos.Organization
{
    public class UpdateCompanySettingDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int TicketExpirationDays { get; set; }
        public int TicketExpiryReminderDays { get; set; }
        public bool AllowPastDateLeaveRequests { get; set; }
        public bool CountWeekendsAsLeaveDays { get; set; }
        public bool CountPublicHolidaysAsLeaveDays { get; set; }
        public int DefaultAnnualLeaveDays { get; set; }
        public bool SaturdayIsWeekend { get; set; }
        public bool SundayIsWeekend { get; set; }
        public bool AllowMultipleAttendancePunchesPerDay { get; set; }
        public int AssetReturnReminderDays { get; set; }
    }
}