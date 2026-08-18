using Em.Core.Application.CQRS.Tickets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetByIdGeneralTicketQueryHandler : IRequestHandler<GetByIdGeneralTicketQuery, GetByIdGeneralTicketDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdGeneralTicketQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdGeneralTicketDto?> Handle(GetByIdGeneralTicketQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<GeneralTicket>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<GeneralTicket, GetByIdGeneralTicketDto>(entity);
        }
    }
}
