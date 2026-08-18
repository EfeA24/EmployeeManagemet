using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Tickets
{
    public class CreateTicketApprovalWorkflowStageDto
    {
        public Guid CompanyId { get; set; }
        public Guid WorkflowId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; } = null!;
        public Guid? TargetDepartmentId { get; set; }
        public Guid? RequiredRoleId { get; set; }
    }
}