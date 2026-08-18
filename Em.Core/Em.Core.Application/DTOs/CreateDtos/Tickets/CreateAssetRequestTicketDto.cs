using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Tickets
{
    public class CreateAssetRequestTicketDto : CreateTicketDto
    {
        public string RequestedAssetCategory { get; set; } = null!;
        public DateTime NeededFrom { get; set; }
        public DateTime NeededUntil { get; set; }
        public Guid? PreferredAssetId { get; set; }
    }
}