using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateGeneralTicketCommandHandler : IRequestHandler<UpdateGeneralTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGeneralTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateGeneralTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GeneralTicketRepository.GetByIdAsync(request.UpdateGeneralTicketDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateGeneralTicketDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.GeneralTicketRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
