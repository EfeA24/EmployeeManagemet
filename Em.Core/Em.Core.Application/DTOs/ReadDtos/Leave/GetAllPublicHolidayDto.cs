using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Leave
{
    public class GetAllPublicHolidayDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly Date { get; set; }
        public bool IsRecurring { get; set; }
    }
}