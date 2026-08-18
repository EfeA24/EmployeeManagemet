using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateTicketDecisionCommandHandler : IRequestHandler<UpdateTicketDecisionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketDecisionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateTicketDecisionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketDecisionRepository.GetByIdAsync(request.UpdateTicketDecisionDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateTicketDecisionDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketDecisionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
