using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Organization
{
    public class CreateEmployeeDepartmentHistoryDto
    {
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? ChangeNote { get; set; }
    }
}