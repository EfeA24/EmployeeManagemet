using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Tickets
{
    public class CreateTicketApprovalPermissionDto
    {
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
        public TicketType? TicketType { get; set; }
        public bool CanApprove { get; set; }
        public bool CanReject { get; set; }
        public bool IsActive { get; set; } = true;
    }
}