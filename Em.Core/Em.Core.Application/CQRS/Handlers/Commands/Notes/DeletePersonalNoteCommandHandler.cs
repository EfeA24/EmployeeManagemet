using MediatR;
using Em.Core.Application.CQRS.Commands.Notes;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notes
{
    public class DeletePersonalNoteCommandHandler : IRequestHandler<DeletePersonalNoteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonalNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePersonalNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PersonalNoteRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.PersonalNoteRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
