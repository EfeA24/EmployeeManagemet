using Em.Core.Domain.Entities.Organization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Generic
{
    public abstract class TenantEntity : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
    }
}
