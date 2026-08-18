using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Attendance
{
    public class UpdateAttendanceRecordDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateOnly WorkDate { get; set; }
        public DateTime? CheckInAt { get; set; }
        public DateTime? CheckOutAt { get; set; }
        public int WorkedMinutes { get; set; }
        public AttendanceStatus Status { get; set; }
        public bool IsWeekend { get; set; }
        public bool IsPublicHoliday { get; set; }
        public string? Note { get; set; }
    }
}