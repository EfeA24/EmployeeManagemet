using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Notifications
{
    public class GetAllNotificationDeliveryDto
    {
        public Guid Id { get; set; }
        public Guid NotificationId { get; set; }
        public NotificationChannel Channel { get; set; }
        public NotificationDeliveryStatus Status { get; set; }
        public int RetryCount { get; set; }
        public DateTime? SentAt { get; set; }
    }
}