using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Notifications
{
    public class CreateDeviceTokenDto
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}