using Em.Core.Application.CQRS.Tickets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetByIdLeaveTicketQueryHandler : IRequestHandler<GetByIdLeaveTicketQuery, GetByIdLeaveTicketDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdLeaveTicketQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdLeaveTicketDto?> Handle(GetByIdLeaveTicketQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<LeaveTicket>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<LeaveTicket, GetByIdLeaveTicketDto>(entity);
        }
    }
}
