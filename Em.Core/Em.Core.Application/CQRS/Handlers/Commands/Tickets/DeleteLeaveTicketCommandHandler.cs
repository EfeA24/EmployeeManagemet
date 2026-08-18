using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteLeaveTicketCommandHandler : IRequestHandler<DeleteLeaveTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLeaveTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteLeaveTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LeaveTicketRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.LeaveTicketRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
