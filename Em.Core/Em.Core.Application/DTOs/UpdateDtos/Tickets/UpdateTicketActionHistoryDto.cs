using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Tickets
{
    public class UpdateTicketActionHistoryDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid TicketId { get; set; }
        public TicketActionType ActionType { get; set; }
        public Guid? PerformedByEmployeeId { get; set; }
        public string? Note { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}