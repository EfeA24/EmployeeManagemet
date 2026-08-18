using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetByIdTicketApprovalWorkflowStageDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid WorkflowId { get; set; }
        public string WorkflowName { get; set; } = null!;
        public int Order { get; set; }
        public string Name { get; set; } = null!;
        public Guid? TargetDepartmentId { get; set; }
        public string? TargetDepartmentName { get; set; }
        public Guid? RequiredRoleId { get; set; }
        public string? RequiredRoleName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}