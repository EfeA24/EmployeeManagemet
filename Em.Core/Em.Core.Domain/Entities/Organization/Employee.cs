using Em.Core.Domain.Entities.Assets;
using Em.Core.Domain.Entities.Attendance;
using Em.Core.Domain.Entities.Notes;
using Em.Core.Domain.Entities.Tickets;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Organization
{
    public class Employee : BaseEntity
    {
        public Guid UserId { get; set; }

        public string? EmployeeNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }
        public string? JobTitle { get; set; }

        public DateOnly HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; }
            = new List<Ticket>();

        public ICollection<AssetAssignment> AssetAssignments { get; set; }
            = new List<AssetAssignment>();

        public ICollection<AttendanceRecord> AttendanceRecords { get; set; }
            = new List<AttendanceRecord>();

        public ICollection<PersonalNote> PersonalNotes { get; set; }
            = new List<PersonalNote>();
    }
}
