using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Tickets
{
    public class UpdateTicketDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Subject { get; set; } = null!;
        public string? Description { get; set; }
        public TicketStatus Status { get; set; }
        public Guid RequestedByEmployeeId { get; set; }
        public Guid TargetDepartmentId { get; set; }
    }
}