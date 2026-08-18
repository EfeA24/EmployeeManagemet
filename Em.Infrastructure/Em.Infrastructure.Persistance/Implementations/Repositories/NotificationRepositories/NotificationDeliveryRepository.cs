using Em.Core.Application.Interfaces.Repositories.NotificationRepositories;
using Em.Core.Domain.Entities.Notifications;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.NotificationRepositories
{
    public class NotificationDeliveryRepository : GenericRepository<NotificationDelivery>, INotificationDeliveryRepository
    {
        public NotificationDeliveryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
