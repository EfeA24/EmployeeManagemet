using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Organization
{
    public class UpdateCompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LegalName { get; set; }
        public string? TaxNumber { get; set; }
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }
        public CompanyStatus Status { get; set; }
        public int PersonnelLimit { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public DateTime? GracePeriodEndDate { get; set; }
        public DateTime? WarnedAt { get; set; }
    }
}