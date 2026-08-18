using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Leave
{
    public class PublicHoliday : TenantEntity
    {
        public string Name { get; set; } = null!;
        public DateOnly Date { get; set; }
        public bool IsRecurring { get; set; }
    }
}
