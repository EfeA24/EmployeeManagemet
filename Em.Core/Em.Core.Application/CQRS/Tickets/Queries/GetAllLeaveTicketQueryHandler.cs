using Em.Core.Application.CQRS.Tickets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetAllLeaveTicketQueryHandler : IRequestHandler<GetAllLeaveTicketQuery, IReadOnlyList<GetAllLeaveTicketDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllLeaveTicketQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllLeaveTicketDto>> Handle(GetAllLeaveTicketQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<LeaveTicket>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<LeaveTicket, GetAllLeaveTicketDto>)
                .ToList();
        }
    }
}
