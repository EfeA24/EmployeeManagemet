using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.UpdateDtos.Tickets
{
    public class UpdateTicketApprovalWorkflowStageDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid WorkflowId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; } = null!;
        public Guid? TargetDepartmentId { get; set; }
        public Guid? RequiredRoleId { get; set; }
    }
}