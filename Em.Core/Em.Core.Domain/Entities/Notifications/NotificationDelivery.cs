using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Notifications
{
    public class NotificationDelivery : TenantEntity
    {
        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; } = null!;

        public NotificationChannel Channel { get; set; }
        public NotificationDeliveryStatus Status { get; set; }
            = NotificationDeliveryStatus.Pending;

        public int RetryCount { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? NextRetryAt { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
