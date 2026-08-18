using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetAllApprovalDelegationDto
    {
        public Guid Id { get; set; }
        public Guid FromEmployeeId { get; set; }
        public string FromEmployeeName { get; set; } = null!;
        public Guid ToEmployeeId { get; set; }
        public string ToEmployeeName { get; set; } = null!;
        public TicketType? TicketType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}