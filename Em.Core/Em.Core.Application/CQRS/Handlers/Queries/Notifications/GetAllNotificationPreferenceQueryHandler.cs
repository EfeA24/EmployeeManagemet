using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
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
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
