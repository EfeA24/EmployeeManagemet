using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Assets
{
    public class GetByIdAssetAssignmentDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid AssetId { get; set; }
        public string AssetName { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public Guid? AssignedByEmployeeId { get; set; }
        public string? AssignedByEmployeeName { get; set; }
        public Guid? SourceTicketId { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? ExpectedReturnAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public string? AssignmentNote { get; set; }
        public string? ReturnNote { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}