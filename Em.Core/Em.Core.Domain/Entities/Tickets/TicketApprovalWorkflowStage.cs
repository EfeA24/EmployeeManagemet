using Em.Core.Domain.Entities.Identity;
using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public class TicketApprovalWorkflowStage : TenantEntity
    {
        public Guid WorkflowId { get; set; }
        public TicketApprovalWorkflow Workflow { get; set; } = null!;

        public int Order { get; set; }
        public string Name { get; set; } = null!;

        public Guid? TargetDepartmentId { get; set; }
        public Department? TargetDepartment { get; set; }

        public Guid? RequiredRoleId { get; set; }
        public Role? RequiredRole { get; set; }
    }
}
