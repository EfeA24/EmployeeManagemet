using Em.Core.Domain.Entities.Identity;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Organization
{
    public class Company : BaseEntity
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
        public DateTime? WarnedAt { get; set; }

        public CompanySetting Setting { get; set; } = null!;

        public ICollection<User> Users { get; set; }
            = new List<User>();

        public ICollection<Department> Departments { get; set; }
            = new List<Department>();

        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();

        public ICollection<SubscriptionPeriod> SubscriptionPeriods { get; set; }
            = new List<SubscriptionPeriod>();
    }
}
