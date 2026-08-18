using Em.Core.Domain.Entities.Identity;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Audit
{
    public class AuditLog : TenantEntity
    {
        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public string Action { get; set; } = null!;
        public string EntityType { get; set; } = null!;
        public Guid? EntityId { get; set; }

        public string? OldValues { get; set; }
        public string? NewValues { get; set; }

        public string? IpAddress { get; set; }
        public DateTime OccurredAt { get; set; }
    }
}
