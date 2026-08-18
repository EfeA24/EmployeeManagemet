using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Entities.Tickets;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Assets
{
    public class AssetAssignment : TenantEntity
    {
        public Guid AssetId { get; set; }
        public Asset Asset { get; set; } = null!;

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public Guid? AssignedByEmployeeId { get; set; }
        public Employee? AssignedByEmployee { get; set; }

        public Guid? SourceTicketId { get; set; }
        public Ticket? SourceTicket { get; set; }

        public DateTime AssignedAt { get; set; }
        public DateTime? ExpectedReturnAt { get; set; }
        public DateTime? ReturnedAt { get; set; }

        public string? AssignmentNote { get; set; }
        public string? ReturnNote { get; set; }
    }
}
