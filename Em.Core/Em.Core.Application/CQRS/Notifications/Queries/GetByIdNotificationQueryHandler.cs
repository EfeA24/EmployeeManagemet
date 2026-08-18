using Em.Core.Application.CQRS.Notifications.Queries;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetByIdNotificationQueryHandler : IRequestHandler<GetByIdNotificationQuery, GetByIdNotificationDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdNotificationQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdNotificationDto?> Handle(GetByIdNotificationQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<Notification>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Notification, GetByIdNotificationDto>(entity);
        }
    }
}
