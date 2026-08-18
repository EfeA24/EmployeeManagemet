using Em.Core.Domain.Entities.Tickets;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Organization
{
    public class Department : TenantEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();

        public ICollection<TicketApprovalPermission> ApprovalPermissions { get; set; }
            = new List<TicketApprovalPermission>();
    }
}
