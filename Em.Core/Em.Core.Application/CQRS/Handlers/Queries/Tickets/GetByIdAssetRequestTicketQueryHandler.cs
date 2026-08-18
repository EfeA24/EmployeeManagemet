using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetByIdAssetRequestTicketQueryHandler : IRequestHandler<GetByIdAssetRequestTicketQuery, GetByIdAssetRequestTicketDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdAssetRequestTicketQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdAssetRequestTicketDto?> Handle(GetByIdAssetRequestTicketQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<AssetRequestTicket>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return entity.ToGetByIdDto();
        }
    }
}
