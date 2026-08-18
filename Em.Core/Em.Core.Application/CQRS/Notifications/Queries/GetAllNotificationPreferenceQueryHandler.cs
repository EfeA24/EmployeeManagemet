using Em.Core.Application.CQRS.Notifications.Queries;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetAllNotificationPreferenceQueryHandler : IRequestHandler<GetAllNotificationPreferenceQuery, IReadOnlyList<GetAllNotificationPreferenceDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllNotificationPreferenceQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllNotificationPreferenceDto>> Handle(GetAllNotificationPreferenceQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<NotificationPreference>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<NotificationPreference, GetAllNotificationPreferenceDto>)
                .ToList();
        }
    }
}
