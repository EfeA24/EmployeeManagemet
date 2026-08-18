using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Identity
{
    public class CreateRolePermissionDto
    {
        public Guid CompanyId { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
    }
}