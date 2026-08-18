using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Notes
{
    public class GetAllPersonalNoteDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Title { get; set; } = null!;
        public bool IsPinned { get; set; }
        public DateTime? ReminderAt { get; set; }
    }
}