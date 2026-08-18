using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteTicketActionHistoryCommandHandler : IRequestHandler<DeleteTicketActionHistoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketActionHistoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTicketActionHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketActionHistoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.TicketActionHistoryRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
