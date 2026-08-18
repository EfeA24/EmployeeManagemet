using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Leave
{
    public class GetAllLeaveBalanceDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int Year { get; set; }
        public LeaveType LeaveType { get; set; }
        public decimal RemainingDays { get; set; }
    }
}