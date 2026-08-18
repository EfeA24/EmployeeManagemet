using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Tickets
{
    public class UpdateApprovalDelegationDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid FromEmployeeId { get; set; }
        public Guid ToEmployeeId { get; set; }
        public Guid? DepartmentId { get; set; }
        public TicketType? TicketType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}