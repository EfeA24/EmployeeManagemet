using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetAllTicketAttachmentDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string FileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public long FileSize { get; set; }
    }
}