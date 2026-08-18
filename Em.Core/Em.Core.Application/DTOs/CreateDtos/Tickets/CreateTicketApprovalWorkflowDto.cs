using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Tickets
{
    public class CreateTicketApprovalWorkflowDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public TicketType TicketType { get; set; }
        public bool IsActive { get; set; } = true;
    }
}