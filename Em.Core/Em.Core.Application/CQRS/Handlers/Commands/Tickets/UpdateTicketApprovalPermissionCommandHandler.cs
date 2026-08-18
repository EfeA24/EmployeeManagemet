using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateTicketApprovalPermissionCommandHandler : IRequestHandler<UpdateTicketApprovalPermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketApprovalPermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateTicketApprovalPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalPermissionRepository.GetByIdAsync(request.UpdateTicketApprovalPermissionDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateTicketApprovalPermissionDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketApprovalPermissionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
