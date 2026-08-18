using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Audit
{
    public class GetByIdAuditLogDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? UserId { get; set; }
        public string? UserEmail { get; set; }
        public string Action { get; set; } = null!;
        public string EntityType { get; set; } = null!;
        public Guid? EntityId { get; set; }
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string? IpAddress { get; set; }
        public DateTime OccurredAt { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}