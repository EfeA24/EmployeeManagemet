using Em.Core.Application.CQRS.Tickets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetByIdTicketActionHistoryQueryHandler : IRequestHandler<GetByIdTicketActionHistoryQuery, GetByIdTicketActionHistoryDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdTicketActionHistoryQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdTicketActionHistoryDto?> Handle(GetByIdTicketActionHistoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<TicketActionHistory>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<TicketActionHistory, GetByIdTicketActionHistoryDto>(entity);
        }
    }
}
