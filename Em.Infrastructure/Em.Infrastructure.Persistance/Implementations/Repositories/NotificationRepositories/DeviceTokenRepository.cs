using Em.Core.Application.Interfaces.Repositories.NotificationRepositories;
using Em.Core.Domain.Entities.Notifications;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.NotificationRepositories
{
    public class DeviceTokenRepository : GenericRepository<DeviceToken>, IDeviceTokenRepository
    {
        public DeviceTokenRepository(AppDbContext context) : base(context)
        {
        }
    }
}
