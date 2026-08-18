using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Notifications
{
    public class CreateNotificationDeliveryDto
    {
        public Guid CompanyId { get; set; }
        public Guid NotificationId { get; set; }
        public NotificationChannel Channel { get; set; }
    }
}