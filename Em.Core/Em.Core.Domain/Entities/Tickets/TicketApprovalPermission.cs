using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public class TicketApprovalPermission : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public TicketType? TicketType { get; set; }

        public bool CanApprove { get; set; }
        public bool CanReject { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
