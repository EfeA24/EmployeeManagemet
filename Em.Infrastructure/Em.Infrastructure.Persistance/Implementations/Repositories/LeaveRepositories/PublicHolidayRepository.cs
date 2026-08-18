using Em.Core.Application.Interfaces.Repositories.LeaveRepositories;
using Em.Core.Domain.Entities.Leave;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.LeaveRepositories
{
    public class PublicHolidayRepository : GenericRepository<PublicHoliday>, IPublicHolidayRepository
    {
        public PublicHolidayRepository(AppDbContext context) : base(context)
        {
        }
    }
}
