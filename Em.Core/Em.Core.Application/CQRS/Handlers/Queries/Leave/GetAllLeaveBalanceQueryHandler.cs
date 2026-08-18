using MediatR;
using Em.Core.Application.CQRS.Queries.Leave;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Domain.Entities.Leave;

namespace Em.Core.Application.CQRS.Handlers.Queries.Leave
{
    public class GetAllLeaveBalanceQueryHandler : IRequestHandler<GetAllLeaveBalanceQuery, IReadOnlyList<GetAllLeaveBalanceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllLeaveBalanceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllLeaveBalanceDto>> Handle(GetAllLeaveBalanceQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.LeaveBalanceRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<LeaveBalance, GetAllLeaveBalanceDto>)
                .ToList();
}
}
}
