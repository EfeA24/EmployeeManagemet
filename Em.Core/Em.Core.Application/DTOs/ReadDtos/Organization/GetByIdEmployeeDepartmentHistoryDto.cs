using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Organization
{
    public class GetByIdEmployeeDepartmentHistoryDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? ChangeNote { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}