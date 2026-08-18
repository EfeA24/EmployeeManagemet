using Em.Core.Application.CQRS.Tickets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetByIdTicketQueryHandler : IRequestHandler<GetByIdTicketQuery, GetByIdTicketDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdTicketQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdTicketDto?> Handle(GetByIdTicketQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<Ticket>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Ticket, GetByIdTicketDto>(entity);
        }
    }
}
