using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Exports
{
    public class GetByIdDataExportRequestDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid RequestedByUserId { get; set; }
        public string RequestedByUserEmail { get; set; } = null!;
        public DataExportStatus Status { get; set; }
        public string? FilePath { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}