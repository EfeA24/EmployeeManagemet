using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Exports
{
    public class GetAllDataExportRequestDto
    {
        public Guid Id { get; set; }
        public Guid RequestedByUserId { get; set; }
        public string RequestedByUserEmail { get; set; } = null!;
        public DataExportStatus Status { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime CreateDate { get; set; }
    }
}