using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetAllTicketDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string TicketNumber { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public TicketType Type { get; set; }
        public TicketStatus Status { get; set; }
        public Guid RequestedByEmployeeId { get; set; }
        public string RequestedByEmployeeName { get; set; } = null!;
        public Guid TargetDepartmentId { get; set; }
        public string TargetDepartmentName { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
    }
}