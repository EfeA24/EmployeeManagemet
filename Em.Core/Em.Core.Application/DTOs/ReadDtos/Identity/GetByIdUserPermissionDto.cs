using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.ReadDtos.Identity
{
    public class GetByIdUserPermissionDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; } = null!;
        public Guid PermissionId { get; set; }
        public string PermissionCode { get; set; } = null!;
        public string PermissionName { get; set; } = null!;
        public bool IsGranted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}