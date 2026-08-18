using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Assets
{
    public class GetAllAssetDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string AssetTag { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public AssetStatus Status { get; set; }
    }
}