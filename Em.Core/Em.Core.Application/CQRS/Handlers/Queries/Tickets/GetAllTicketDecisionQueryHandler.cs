using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllTicketDecisionQueryHandler : IRequestHandler<GetAllTicketDecisionQuery, IReadOnlyList<GetAllTicketDecisionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTicketDecisionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllTicketDecisionDto>> Handle(GetAllTicketDecisionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.TicketDecisionRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<TicketDecision, GetAllTicketDecisionDto>)
                .ToList();
}
}
}
