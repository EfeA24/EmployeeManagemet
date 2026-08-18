using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Notifications
{
    public class GetAllDeviceTokenDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Platform { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}