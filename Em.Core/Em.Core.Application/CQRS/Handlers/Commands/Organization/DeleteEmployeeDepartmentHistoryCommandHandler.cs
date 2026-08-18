using MediatR;
using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class DeleteEmployeeDepartmentHistoryCommandHandler : IRequestHandler<DeleteEmployeeDepartmentHistoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeDepartmentHistoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteEmployeeDepartmentHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.EmployeeDepartmentHistoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.EmployeeDepartmentHistoryRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
