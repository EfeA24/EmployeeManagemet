using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Notifications
{
    public class CreateNotificationPreferenceDto
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool InAppEnabled { get; set; } = true;
        public bool EmailEnabled { get; set; } = true;
        public bool PushEnabled { get; set; }
    }
}