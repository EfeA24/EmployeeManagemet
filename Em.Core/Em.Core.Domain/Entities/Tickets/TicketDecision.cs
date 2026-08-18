using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public class TicketDecision : TenantEntity
    {
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        public Guid? WorkflowStageId { get; set; }
        public TicketApprovalWorkflowStage? WorkflowStage { get; set; }
        public int StageOrder { get; set; }

        public Guid DecidedByEmployeeId { get; set; }
        public Employee DecidedByEmployee { get; set; } = null!;

        public TicketStatus Decision { get; set; }

        public string? Note { get; set; }

        public DateTime DecidedAt { get; set; }
    }
}
