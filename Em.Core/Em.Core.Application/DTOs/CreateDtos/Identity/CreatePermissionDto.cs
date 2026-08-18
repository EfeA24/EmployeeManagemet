using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Identity
{
    public class CreatePermissionDto
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Group { get; set; }
    }
}