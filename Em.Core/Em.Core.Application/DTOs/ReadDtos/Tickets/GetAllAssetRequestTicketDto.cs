using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetAllAssetRequestTicketDto : GetAllTicketDto
    {
        public string RequestedAssetCategory { get; set; } = null!;
        public DateTime NeededFrom { get; set; }
        public DateTime NeededUntil { get; set; }
        public Guid? PreferredAssetId { get; set; }
        public Guid? AssignedAssetId { get; set; }
    }
}