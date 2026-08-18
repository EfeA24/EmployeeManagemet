using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteTicketAttachmentCommandHandler : IRequestHandler<DeleteTicketAttachmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketAttachmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTicketAttachmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketAttachmentRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.TicketAttachmentRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
