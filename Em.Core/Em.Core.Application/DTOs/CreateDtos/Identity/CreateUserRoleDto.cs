using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Identity
{
    public class CreateUserRoleDto
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}