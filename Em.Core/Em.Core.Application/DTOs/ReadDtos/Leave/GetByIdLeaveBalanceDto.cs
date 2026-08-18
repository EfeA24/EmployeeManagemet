using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Leave
{
    public class GetByIdLeaveBalanceDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int Year { get; set; }
        public LeaveType LeaveType { get; set; }
        public decimal EntitledDays { get; set; }
        public decimal UsedDays { get; set; }
        public decimal PendingDays { get; set; }
        public decimal RemainingDays { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}