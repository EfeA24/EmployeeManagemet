using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteGeneralTicketCommandHandler : IRequestHandler<DeleteGeneralTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGeneralTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteGeneralTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GeneralTicketRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.GeneralTicketRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
