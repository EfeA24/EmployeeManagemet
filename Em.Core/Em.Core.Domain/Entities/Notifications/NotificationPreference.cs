using Em.Core.Domain.Entities.Identity;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Notifications
{
    public class NotificationPreference : TenantEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public NotificationType NotificationType { get; set; }

        public bool InAppEnabled { get; set; } = true;
        public bool EmailEnabled { get; set; } = true;
        public bool PushEnabled { get; set; }
    }
}
