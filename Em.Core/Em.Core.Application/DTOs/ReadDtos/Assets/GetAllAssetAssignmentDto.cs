using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Assets
{
    public class GetAllAssetAssignmentDto
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public string AssetName { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public DateTime AssignedAt { get; set; }
        public DateTime? ExpectedReturnAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}