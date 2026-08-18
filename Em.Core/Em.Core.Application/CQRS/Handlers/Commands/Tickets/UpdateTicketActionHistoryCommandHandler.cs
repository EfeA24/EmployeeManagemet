using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateTicketActionHistoryCommandHandler : IRequestHandler<UpdateTicketActionHistoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketActionHistoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateTicketActionHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketActionHistoryRepository.GetByIdAsync(request.UpdateTicketActionHistoryDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateTicketActionHistoryDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketActionHistoryRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
