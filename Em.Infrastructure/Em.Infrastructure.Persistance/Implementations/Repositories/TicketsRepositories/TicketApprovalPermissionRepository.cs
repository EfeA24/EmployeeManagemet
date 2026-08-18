using Em.Core.Application.Interfaces.Repositories.TicketsRepositories;
using Em.Core.Domain.Entities.Tickets;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.TicketsRepositories
{
    public class TicketApprovalPermissionRepository : GenericRepository<TicketApprovalPermission>, ITicketApprovalPermissionRepository
    {
        public TicketApprovalPermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
