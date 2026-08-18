using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Notifications
{
    public class GetAllNotificationDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public NotificationType Type { get; set; }
        public string Title { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime CreateDate { get; set; }
    }
}