using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateTicketAttachmentCommandHandler : IRequestHandler<UpdateTicketAttachmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketAttachmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateTicketAttachmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketAttachmentRepository.GetByIdAsync(request.UpdateTicketAttachmentDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateTicketAttachmentDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketAttachmentRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
