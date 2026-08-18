using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Notifications
{
    public class GetAllNotificationPreferenceDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool InAppEnabled { get; set; }
        public bool EmailEnabled { get; set; }
        public bool PushEnabled { get; set; }
    }
}