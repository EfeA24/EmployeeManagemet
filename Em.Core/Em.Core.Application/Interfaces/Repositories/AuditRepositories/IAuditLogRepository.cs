using Em.Core.Application.Interfaces.Generic;
using Em.Core.Domain.Entities.Audit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.Interfaces.Repositories.AuditRepositories
{
    public interface IAuditLogRepository : IGenericRepository<AuditLog>
    {
    }
}
