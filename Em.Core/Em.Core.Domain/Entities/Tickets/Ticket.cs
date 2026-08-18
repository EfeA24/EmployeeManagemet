using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public abstract class Ticket : TenantEntity
    {
        public string TicketNumber { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string? Description { get; set; }

        public TicketType Type { get; protected set; }
        public TicketStatus Status { get; set; } = TicketStatus.Pending;

        public DateTime ExpiresAt { get; set; }
        public DateTime? ReminderSentAt { get; set; }
        public DateTime? ResolvedAt { get; set; }

        public int CurrentStageOrder { get; set; } = 1;

        public Guid RequestedByEmployeeId { get; set; }
        public Employee RequestedByEmployee { get; set; } = null!;

        public Guid TargetDepartmentId { get; set; }
        public Department TargetDepartment { get; set; } = null!;

        public ICollection<TicketDecision> Decisions { get; set; }
            = new List<TicketDecision>();

        public ICollection<TicketActionHistory> ActionHistory { get; set; }
            = new List<TicketActionHistory>();

        public ICollection<TicketAttachment> Attachments { get; set; }
            = new List<TicketAttachment>();
    }
}
