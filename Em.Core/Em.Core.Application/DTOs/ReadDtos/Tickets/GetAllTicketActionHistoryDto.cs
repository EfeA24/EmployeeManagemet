using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetAllTicketActionHistoryDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public TicketActionType ActionType { get; set; }
        public Guid? PerformedByEmployeeId { get; set; }
        public string? PerformedByEmployeeName { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}