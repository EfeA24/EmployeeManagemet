using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllTicketAttachmentQueryHandler : IRequestHandler<GetAllTicketAttachmentQuery, IReadOnlyList<GetAllTicketAttachmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTicketAttachmentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllTicketAttachmentDto>> Handle(GetAllTicketAttachmentQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.TicketAttachmentRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<TicketAttachment, GetAllTicketAttachmentDto>)
                .ToList();
}
}
}
