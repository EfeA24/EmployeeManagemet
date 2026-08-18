using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetByIdTicketDecisionQueryHandler : IRequestHandler<GetByIdTicketDecisionQuery, GetByIdTicketDecisionDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdTicketDecisionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdTicketDecisionDto?> Handle(GetByIdTicketDecisionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketDecisionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<TicketDecision, GetByIdTicketDecisionDto>(entity);
}
}
}
