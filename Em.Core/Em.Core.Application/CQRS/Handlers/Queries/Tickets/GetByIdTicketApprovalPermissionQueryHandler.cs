using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetByIdTicketApprovalPermissionQueryHandler : IRequestHandler<GetByIdTicketApprovalPermissionQuery, GetByIdTicketApprovalPermissionDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdTicketApprovalPermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdTicketApprovalPermissionDto?> Handle(GetByIdTicketApprovalPermissionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalPermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<TicketApprovalPermission, GetByIdTicketApprovalPermissionDto>(entity);
}
}
}
