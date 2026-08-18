using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Attendance
{
    public class CreateAttendanceRecordDto
    {
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateOnly WorkDate { get; set; }
        public DateTime? CheckInAt { get; set; }
        public DateTime? CheckOutAt { get; set; }
        public AttendanceStatus Status { get; set; }
        public string? Note { get; set; }
    }
}