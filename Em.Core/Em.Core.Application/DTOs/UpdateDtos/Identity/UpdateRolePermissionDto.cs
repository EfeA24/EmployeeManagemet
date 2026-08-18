using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.UpdateDtos.Identity
{
    public class UpdateRolePermissionDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
    }
}