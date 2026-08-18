using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public class TicketApprovalWorkflow : TenantEntity
    {
        public string Name { get; set; } = null!;
        public TicketType TicketType { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<TicketApprovalWorkflowStage> Stages { get; set; }
            = new List<TicketApprovalWorkflowStage>();
    }
}
