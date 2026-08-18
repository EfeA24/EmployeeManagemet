using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllGeneralTicketQueryHandler : IRequestHandler<GetAllGeneralTicketQuery, IReadOnlyList<GetAllGeneralTicketDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllGeneralTicketQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllGeneralTicketDto>> Handle(GetAllGeneralTicketQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<GeneralTicket>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
