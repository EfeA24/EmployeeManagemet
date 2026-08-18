using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
{
    public class GetAllNotificationQueryHandler : IRequestHandler<GetAllNotificationQuery, IReadOnlyList<GetAllNotificationDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllNotificationQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllNotificationDto>> Handle(GetAllNotificationQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<Notification>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
