using Em.Core.Domain.Entities.Identity;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Notifications
{
    public class Notification : TenantEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public NotificationType Type { get; set; }

        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;

        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }

        public Guid? RelatedEntityId { get; set; }
        public string? RelatedEntityType { get; set; }

        public ICollection<NotificationDelivery> Deliveries { get; set; }
            = new List<NotificationDelivery>();
    }
}
