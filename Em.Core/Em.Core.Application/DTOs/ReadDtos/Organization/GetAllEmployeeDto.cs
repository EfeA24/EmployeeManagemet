using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Organization
{
    public class GetAllEmployeeDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string EmployeeNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? JobTitle { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}