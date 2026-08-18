using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetByIdTicketActionHistoryDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid TicketId { get; set; }
        public TicketActionType ActionType { get; set; }
        public Guid? PerformedByEmployeeId { get; set; }
        public string? PerformedByEmployeeName { get; set; }
        public string? Note { get; set; }
        public DateTime PerformedAt { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}