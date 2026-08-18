using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public class ApprovalDelegation : TenantEntity
    {
        public Guid FromEmployeeId { get; set; }
        public Employee FromEmployee { get; set; } = null!;

        public Guid ToEmployeeId { get; set; }
        public Employee ToEmployee { get; set; } = null!;

        public Guid? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public TicketType? TicketType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
