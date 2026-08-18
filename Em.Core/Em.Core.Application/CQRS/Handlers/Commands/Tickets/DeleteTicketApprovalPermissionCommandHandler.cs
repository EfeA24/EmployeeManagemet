using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteTicketApprovalPermissionCommandHandler : IRequestHandler<DeleteTicketApprovalPermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketApprovalPermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTicketApprovalPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalPermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.TicketApprovalPermissionRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
