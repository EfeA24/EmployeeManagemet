using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Leave
{
    public class CreatePublicHolidayDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly Date { get; set; }
        public bool IsRecurring { get; set; }
    }
}