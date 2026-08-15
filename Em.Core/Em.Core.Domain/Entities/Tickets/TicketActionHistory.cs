using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public class TicketActionHistory : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        public TicketActionType ActionType { get; set; }

        public Guid? PerformedByEmployeeId { get; set; }
        public Employee? PerformedByEmployee { get; set; }

        public string? Note { get; set; }

        public DateTime PerformedAt { get; set; }
    }
}
