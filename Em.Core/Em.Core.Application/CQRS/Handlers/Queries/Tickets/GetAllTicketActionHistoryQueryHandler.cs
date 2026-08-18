using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllTicketActionHistoryQueryHandler : IRequestHandler<GetAllTicketActionHistoryQuery, IReadOnlyList<GetAllTicketActionHistoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTicketActionHistoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllTicketActionHistoryDto>> Handle(GetAllTicketActionHistoryQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.TicketActionHistoryRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<TicketActionHistory, GetAllTicketActionHistoryDto>)
                .ToList();
}
}
}
