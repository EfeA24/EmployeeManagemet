using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Organization
{
    public class GetByIdCompanySettingDto
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
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}