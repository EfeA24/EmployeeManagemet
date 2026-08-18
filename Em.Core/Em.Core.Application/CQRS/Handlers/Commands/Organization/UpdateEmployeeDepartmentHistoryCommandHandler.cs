using MediatR;
using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Organization;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class UpdateEmployeeDepartmentHistoryCommandHandler : IRequestHandler<UpdateEmployeeDepartmentHistoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmployeeDepartmentHistoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateEmployeeDepartmentHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.EmployeeDepartmentHistoryRepository.GetByIdAsync(request.UpdateEmployeeDepartmentHistoryDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateEmployeeDepartmentHistoryDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.EmployeeDepartmentHistoryRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
