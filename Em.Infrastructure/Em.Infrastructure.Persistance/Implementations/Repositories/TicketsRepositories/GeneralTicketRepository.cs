using Em.Core.Application.Interfaces.Repositories.TicketsRepositories;
using Em.Core.Domain.Entities.Tickets;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.TicketsRepositories
{
    public class GeneralTicketRepository : GenericRepository<GeneralTicket>, IGeneralTicketRepository
    {
        public GeneralTicketRepository(AppDbContext context) : base(context)
        {
        }
    }
}
