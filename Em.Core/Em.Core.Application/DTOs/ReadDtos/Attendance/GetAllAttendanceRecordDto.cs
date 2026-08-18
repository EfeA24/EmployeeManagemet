using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Attendance
{
    public class GetAllAttendanceRecordDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public DateOnly WorkDate { get; set; }
        public DateTime? CheckInAt { get; set; }
        public DateTime? CheckOutAt { get; set; }
        public int WorkedMinutes { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}