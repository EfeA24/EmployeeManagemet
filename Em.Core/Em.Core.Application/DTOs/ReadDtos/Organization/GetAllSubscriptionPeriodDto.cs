using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Organization
{
    public class GetAllSubscriptionPeriodDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPaid { get; set; }
        public decimal? Amount { get; set; }
    }
}