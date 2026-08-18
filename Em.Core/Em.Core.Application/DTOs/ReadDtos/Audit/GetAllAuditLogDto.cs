using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Audit
{
    public class GetAllAuditLogDto
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? UserEmail { get; set; }
        public string Action { get; set; } = null!;
        public string EntityType { get; set; } = null!;
        public Guid? EntityId { get; set; }
        public DateTime OccurredAt { get; set; }
    }
}