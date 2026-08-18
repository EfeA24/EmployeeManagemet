using Em.Core.Application.CQRS.Notifications.Queries;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetByIdNotificationPreferenceQueryHandler : IRequestHandler<GetByIdNotificationPreferenceQuery, GetByIdNotificationPreferenceDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdNotificationPreferenceQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdNotificationPreferenceDto?> Handle(GetByIdNotificationPreferenceQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<NotificationPreference>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<NotificationPreference, GetByIdNotificationPreferenceDto>(entity);
        }
    }
}
