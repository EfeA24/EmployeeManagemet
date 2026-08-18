using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteAssetRequestTicketCommandHandler : IRequestHandler<DeleteAssetRequestTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAssetRequestTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAssetRequestTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetRequestTicketRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AssetRequestTicketRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
