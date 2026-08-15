using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Assets
{
    public class Asset : BaseEntity
    {
        public string AssetTag { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;

        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }

        public AssetStatus Status { get; set; }
            = AssetStatus.Available;

        public DateOnly? PurchaseDate { get; set; }
        public string? Description { get; set; }

        public ICollection<AssetAssignment> Assignments { get; set; }
            = new List<AssetAssignment>();
    }
}
