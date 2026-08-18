using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.UpdateDtos.Identity
{
    public class UpdateUserPermissionDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }
        public bool IsGranted { get; set; }
    }
}