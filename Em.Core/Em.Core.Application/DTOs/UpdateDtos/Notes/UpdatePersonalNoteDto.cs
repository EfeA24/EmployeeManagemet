using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.UpdateDtos.Notes
{
    public class UpdatePersonalNoteDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsPinned { get; set; }
        public DateTime? ReminderAt { get; set; }
    }
}