using MediatR;
using Em.Core.Application.CQRS.Queries.Leave;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Domain.Entities.Leave;

namespace Em.Core.Application.CQRS.Handlers.Queries.Leave
{
    public class GetByIdLeaveBalanceQueryHandler : IRequestHandler<GetByIdLeaveBalanceQuery, GetByIdLeaveBalanceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdLeaveBalanceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdLeaveBalanceDto?> Handle(GetByIdLeaveBalanceQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LeaveBalanceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<LeaveBalance, GetByIdLeaveBalanceDto>(entity);
}
}
}
