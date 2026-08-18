using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Organization
{
    public class GetAllDepartmentDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}