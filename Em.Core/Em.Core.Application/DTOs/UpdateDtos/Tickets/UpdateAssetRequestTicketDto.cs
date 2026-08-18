using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.UpdateDtos.Tickets
{
    public class UpdateAssetRequestTicketDto : UpdateTicketDto
    {
        public string RequestedAssetCategory { get; set; } = null!;
        public DateTime NeededFrom { get; set; }
        public DateTime NeededUntil { get; set; }
        public Guid? PreferredAssetId { get; set; }
        public Guid? AssignedAssetId { get; set; }
    }
}