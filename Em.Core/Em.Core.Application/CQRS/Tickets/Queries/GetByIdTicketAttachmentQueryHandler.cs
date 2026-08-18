using Em.Core.Application.CQRS.Tickets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetByIdTicketAttachmentQueryHandler : IRequestHandler<GetByIdTicketAttachmentQuery, GetByIdTicketAttachmentDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdTicketAttachmentQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdTicketAttachmentDto?> Handle(GetByIdTicketAttachmentQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<TicketAttachment>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<TicketAttachment, GetByIdTicketAttachmentDto>(entity);
        }
    }
}
