using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Tickets
{
    public class UpdateTicketApprovalPermissionDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
        public TicketType? TicketType { get; set; }
        public bool CanApprove { get; set; }
        public bool CanReject { get; set; }
        public bool IsActive { get; set; }
    }
}