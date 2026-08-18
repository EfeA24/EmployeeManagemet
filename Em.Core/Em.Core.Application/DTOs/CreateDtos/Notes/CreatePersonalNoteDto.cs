using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Notes
{
    public class CreatePersonalNoteDto
    {
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsPinned { get; set; }
        public DateTime? ReminderAt { get; set; }
    }
}