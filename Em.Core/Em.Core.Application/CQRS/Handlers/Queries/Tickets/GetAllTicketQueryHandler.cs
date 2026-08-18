using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllTicketQueryHandler : IRequestHandler<GetAllTicketQuery, IReadOnlyList<GetAllTicketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTicketQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllTicketDto>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.TicketRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Ticket, GetAllTicketDto>)
                .ToList();
}
}
}
