using MediatR;
using Em.Core.Application.CQRS.Commands.Leave;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Leave;

namespace Em.Core.Application.CQRS.Handlers.Commands.Leave
{
    public class UpdateLeaveBalanceCommandHandler : IRequestHandler<UpdateLeaveBalanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLeaveBalanceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LeaveBalanceRepository.GetByIdAsync(request.UpdateLeaveBalanceDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateLeaveBalanceDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.LeaveBalanceRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
