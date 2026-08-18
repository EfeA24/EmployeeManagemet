using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.CreateDtos.Notifications
{
    public class CreateNotificationDto
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public NotificationType Type { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public Guid? RelatedEntityId { get; set; }
        public string? RelatedEntityType { get; set; }
    }
}