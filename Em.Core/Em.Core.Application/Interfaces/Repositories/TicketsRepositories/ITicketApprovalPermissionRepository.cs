using Em.Core.Application.Interfaces.Generic;
using Em.Core.Domain.Entities.Tickets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.Interfaces.Repositories.TicketsRepositories
{
    public interface ITicketApprovalPermissionRepository : IGenericRepository<TicketApprovalPermission>
    {
    }
}
