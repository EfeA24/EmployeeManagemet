using Em.Core.Domain.Entities.Identity;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Notifications
{
    public class DeviceToken : TenantEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public string Token { get; set; } = null!;
        public string Platform { get; set; } = null!;

        public bool IsActive { get; set; } = true;
    }
}
