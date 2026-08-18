using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.UpdateDtos.Assets
{
    public class UpdateAssetAssignmentDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid AssetId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid? AssignedByEmployeeId { get; set; }
        public Guid? SourceTicketId { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? ExpectedReturnAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public string? AssignmentNote { get; set; }
        public string? ReturnNote { get; set; }
    }
}