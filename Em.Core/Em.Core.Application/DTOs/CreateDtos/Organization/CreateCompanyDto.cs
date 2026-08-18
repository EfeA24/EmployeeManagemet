using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Organization
{
    public class CreateCompanyDto
    {
        public string Name { get; set; } = null!;
        public string? LegalName { get; set; }
        public string? TaxNumber { get; set; }
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public CompanyStatus Status { get; set; } = CompanyStatus.Active;
        public int PersonnelLimit { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public DateTime? GracePeriodEndDate { get; set; }
    }
}