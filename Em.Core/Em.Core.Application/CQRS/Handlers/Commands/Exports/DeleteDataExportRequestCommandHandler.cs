using MediatR;
using Em.Core.Application.CQRS.Commands.Exports;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Exports
{
    public class DeleteDataExportRequestCommandHandler : IRequestHandler<DeleteDataExportRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDataExportRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDataExportRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DataExportRequestRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.DataExportRequestRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
