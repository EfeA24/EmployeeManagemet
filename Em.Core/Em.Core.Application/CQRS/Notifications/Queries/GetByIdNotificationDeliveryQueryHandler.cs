using Em.Core.Application.CQRS.Notifications.Queries;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetByIdNotificationDeliveryQueryHandler : IRequestHandler<GetByIdNotificationDeliveryQuery, GetByIdNotificationDeliveryDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdNotificationDeliveryQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdNotificationDeliveryDto?> Handle(GetByIdNotificationDeliveryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<NotificationDelivery>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<NotificationDelivery, GetByIdNotificationDeliveryDto>(entity);
        }
    }
}
