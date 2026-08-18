using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Notifications
{
    public class UpdateNotificationDeliveryDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid NotificationId { get; set; }
        public NotificationChannel Channel { get; set; }
        public NotificationDeliveryStatus Status { get; set; }
        public int RetryCount { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? NextRetryAt { get; set; }
        public string? ErrorMessage { get; set; }
    }
}