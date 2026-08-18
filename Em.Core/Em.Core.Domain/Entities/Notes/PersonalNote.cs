using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Notes
{
    public class PersonalNote : TenantEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public bool IsPinned { get; set; }

        public DateTime? ReminderAt { get; set; }
    }
}
