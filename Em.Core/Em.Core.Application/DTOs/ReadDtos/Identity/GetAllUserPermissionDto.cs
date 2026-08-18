using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Identity
{
    public class GetAllUserPermissionDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; } = null!;
        public Guid PermissionId { get; set; }
        public string PermissionCode { get; set; } = null!;
        public bool IsGranted { get; set; }
    }
}