using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetAllTicketDecisionDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public int StageOrder { get; set; }
        public Guid DecidedByEmployeeId { get; set; }
        public string DecidedByEmployeeName { get; set; } = null!;
        public TicketStatus Decision { get; set; }
        public DateTime DecidedAt { get; set; }
    }
}