using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Organization
{
    public class GetAllCompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }
        public CompanyStatus Status { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
    }
}