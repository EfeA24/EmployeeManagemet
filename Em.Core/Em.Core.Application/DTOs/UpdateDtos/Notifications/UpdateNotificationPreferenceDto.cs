using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Notifications
{
    public class UpdateNotificationPreferenceDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool InAppEnabled { get; set; }
        public bool EmailEnabled { get; set; }
        public bool PushEnabled { get; set; }
    }
}