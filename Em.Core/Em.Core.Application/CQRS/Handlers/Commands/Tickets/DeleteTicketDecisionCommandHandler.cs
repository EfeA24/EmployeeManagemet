using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteTicketDecisionCommandHandler : IRequestHandler<DeleteTicketDecisionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketDecisionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTicketDecisionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketDecisionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.TicketDecisionRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
