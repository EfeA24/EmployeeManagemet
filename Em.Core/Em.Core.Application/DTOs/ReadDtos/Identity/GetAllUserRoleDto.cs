using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Identity
{
    public class GetAllUserRoleDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = null!;
    }
}