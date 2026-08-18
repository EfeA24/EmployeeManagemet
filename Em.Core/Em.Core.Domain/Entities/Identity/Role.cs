using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Identity
{
    public class Role : TenantEntity
    {
        public string Name { get; set; } = null!;
        public SystemRoleType? SystemRoleType { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<RolePermission> RolePermissions { get; set; }
            = new List<RolePermission>();

        public ICollection<UserRole> UserRoles { get; set; }
            = new List<UserRole>();
    }
}
