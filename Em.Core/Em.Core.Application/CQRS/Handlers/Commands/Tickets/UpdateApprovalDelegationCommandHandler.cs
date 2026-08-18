using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateApprovalDelegationCommandHandler : IRequestHandler<UpdateApprovalDelegationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateApprovalDelegationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateApprovalDelegationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ApprovalDelegationRepository.GetByIdAsync(request.UpdateApprovalDelegationDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateApprovalDelegationDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.ApprovalDelegationRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
