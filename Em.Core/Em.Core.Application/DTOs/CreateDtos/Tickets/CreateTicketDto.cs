using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Tickets
{
    public class CreateTicketDto
    {
        public Guid CompanyId { get; set; }
        public string Subject { get; set; } = null!;
        public string? Description { get; set; }
        public Guid RequestedByEmployeeId { get; set; }
        public Guid TargetDepartmentId { get; set; }
    }
}