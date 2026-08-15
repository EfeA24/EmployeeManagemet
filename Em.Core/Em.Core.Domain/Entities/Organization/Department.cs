using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Organization
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}
