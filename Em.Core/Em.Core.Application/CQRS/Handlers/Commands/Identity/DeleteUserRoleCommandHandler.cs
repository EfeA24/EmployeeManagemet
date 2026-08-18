using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserRoleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.UserRoleRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
