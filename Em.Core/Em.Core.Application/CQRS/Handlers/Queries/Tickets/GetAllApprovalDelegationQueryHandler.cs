using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllApprovalDelegationQueryHandler : IRequestHandler<GetAllApprovalDelegationQuery, IReadOnlyList<GetAllApprovalDelegationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllApprovalDelegationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllApprovalDelegationDto>> Handle(GetAllApprovalDelegationQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.ApprovalDelegationRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<ApprovalDelegation, GetAllApprovalDelegationDto>)
                .ToList();
}
}
}
