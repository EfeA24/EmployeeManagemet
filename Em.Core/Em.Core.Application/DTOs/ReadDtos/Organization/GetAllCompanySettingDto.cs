using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Organization
{
    public class GetAllCompanySettingDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int TicketExpirationDays { get; set; }
        public int DefaultAnnualLeaveDays { get; set; }
    }
}