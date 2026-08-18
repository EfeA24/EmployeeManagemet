using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetByIdTicketApprovalPermissionDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public TicketType? TicketType { get; set; }
        public bool CanApprove { get; set; }
        public bool CanReject { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}