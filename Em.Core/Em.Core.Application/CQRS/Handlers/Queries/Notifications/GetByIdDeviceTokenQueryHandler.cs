using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
{
    public class GetByIdDeviceTokenQueryHandler : IRequestHandler<GetByIdDeviceTokenQuery, GetByIdDeviceTokenDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdDeviceTokenQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdDeviceTokenDto?> Handle(GetByIdDeviceTokenQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<DeviceToken>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return entity.ToGetByIdDto();
        }
    }
}
