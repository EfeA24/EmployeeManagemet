using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.UpdateDtos.Assets
{
    public class UpdateAssetDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string AssetTag { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public AssetStatus Status { get; set; }
        public DateOnly? PurchaseDate { get; set; }
        public string? Description { get; set; }
    }
}