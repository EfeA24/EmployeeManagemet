using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Organization
{
    public class CreateEmployeeDto
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public string EmployeeNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? JobTitle { get; set; }
        public DateOnly HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid DepartmentId { get; set; }
    }
}