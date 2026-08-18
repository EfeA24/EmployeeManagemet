using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Identity
{
    public class CreateRoleDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public SystemRoleType? SystemRoleType { get; set; }
        public bool IsActive { get; set; } = true;
    }
}