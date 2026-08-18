using Em.Core.Application.CQRS.Tickets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetAllAssetRequestTicketQueryHandler : IRequestHandler<GetAllAssetRequestTicketQuery, IReadOnlyList<GetAllAssetRequestTicketDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllAssetRequestTicketQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllAssetRequestTicketDto>> Handle(GetAllAssetRequestTicketQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<AssetRequestTicket>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AssetRequestTicket, GetAllAssetRequestTicketDto>)
                .ToList();
        }
    }
}
