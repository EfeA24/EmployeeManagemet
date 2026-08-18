using Em.Core.Domain.Entities.Identity;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Exports
{
    public class DataExportRequest : TenantEntity
    {
        public Guid RequestedByUserId { get; set; }
        public User RequestedByUser { get; set; } = null!;

        public DataExportStatus Status { get; set; }
            = DataExportStatus.Pending;

        public string? FilePath { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
