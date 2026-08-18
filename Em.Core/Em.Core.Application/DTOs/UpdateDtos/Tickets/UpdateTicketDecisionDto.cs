using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Tickets
{
    public class UpdateTicketDecisionDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid TicketId { get; set; }
        public Guid? WorkflowStageId { get; set; }
        public int StageOrder { get; set; }
        public Guid DecidedByEmployeeId { get; set; }
        public TicketStatus Decision { get; set; }
        public string? Note { get; set; }
        public DateTime DecidedAt { get; set; }
    }
}