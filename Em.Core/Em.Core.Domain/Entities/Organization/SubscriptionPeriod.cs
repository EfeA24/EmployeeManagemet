using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Organization
{
    public class SubscriptionPeriod : TenantEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? GracePeriodEndDate { get; set; }

        public bool IsPaid { get; set; }
        public decimal? Amount { get; set; }

        public string? Note { get; set; }
    }
}
