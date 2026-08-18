using MediatR;
using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Domain.Entities.Organization;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetByIdEmployeeDepartmentHistoryQueryHandler : IRequestHandler<GetByIdEmployeeDepartmentHistoryQuery, GetByIdEmployeeDepartmentHistoryDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdEmployeeDepartmentHistoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdEmployeeDepartmentHistoryDto?> Handle(GetByIdEmployeeDepartmentHistoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.EmployeeDepartmentHistoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<EmployeeDepartmentHistory, GetByIdEmployeeDepartmentHistoryDto>(entity);
}
}
}
