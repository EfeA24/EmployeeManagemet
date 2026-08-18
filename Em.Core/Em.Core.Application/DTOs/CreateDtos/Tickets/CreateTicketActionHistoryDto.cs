using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Tickets
{
    public class CreateTicketActionHistoryDto
    {
        public Guid CompanyId { get; set; }
        public Guid TicketId { get; set; }
        public TicketActionType ActionType { get; set; }
        public Guid? PerformedByEmployeeId { get; set; }
        public string? Note { get; set; }
    }
}