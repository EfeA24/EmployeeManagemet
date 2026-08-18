using Em.Core.Application.CQRS.Notifications.Queries;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetAllDeviceTokenQueryHandler : IRequestHandler<GetAllDeviceTokenQuery, IReadOnlyList<GetAllDeviceTokenDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllDeviceTokenQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllDeviceTokenDto>> Handle(GetAllDeviceTokenQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<DeviceToken>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<DeviceToken, GetAllDeviceTokenDto>)
                .ToList();
        }
    }
}
