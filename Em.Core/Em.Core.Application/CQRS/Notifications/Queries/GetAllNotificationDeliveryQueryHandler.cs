using Em.Core.Application.CQRS.Notifications.Queries;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetAllNotificationDeliveryQueryHandler : IRequestHandler<GetAllNotificationDeliveryQuery, IReadOnlyList<GetAllNotificationDeliveryDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllNotificationDeliveryQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllNotificationDeliveryDto>> Handle(GetAllNotificationDeliveryQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<NotificationDelivery>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<NotificationDelivery, GetAllNotificationDeliveryDto>)
                .ToList();
        }
    }
}
