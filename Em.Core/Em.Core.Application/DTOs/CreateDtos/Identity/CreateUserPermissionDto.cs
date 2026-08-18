using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Identity
{
    public class CreateUserPermissionDto
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }
        public bool IsGranted { get; set; } = true;
    }
}