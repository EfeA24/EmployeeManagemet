using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.DTOs.CreateDtos.Exports
{
    public class CreateDataExportRequestDto
    {
        public Guid CompanyId { get; set; }
        public Guid RequestedByUserId { get; set; }
    }
}