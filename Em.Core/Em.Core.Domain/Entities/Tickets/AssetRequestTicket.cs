using Em.Core.Domain.Entities.Assets;
using Em.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public class AssetRequestTicket : Ticket
    {
        public AssetRequestTicket()
        {
            Type = TicketType.AssetRequest;
        }

        public string RequestedAssetCategory { get; set; } = null!;

        public DateTime NeededFrom { get; set; }
        public DateTime NeededUntil { get; set; }

        public Guid? PreferredAssetId { get; set; }
        public Asset? PreferredAsset { get; set; }

        public Guid? AssignedAssetId { get; set; }
        public Asset? AssignedAsset { get; set; }
    }
}
