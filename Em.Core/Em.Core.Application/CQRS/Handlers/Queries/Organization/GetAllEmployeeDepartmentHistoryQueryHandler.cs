using MediatR;
using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Domain.Entities.Organization;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetAllEmployeeDepartmentHistoryQueryHandler : IRequestHandler<GetAllEmployeeDepartmentHistoryQuery, IReadOnlyList<GetAllEmployeeDepartmentHistoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllEmployeeDepartmentHistoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllEmployeeDepartmentHistoryDto>> Handle(GetAllEmployeeDepartmentHistoryQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.EmployeeDepartmentHistoryRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<EmployeeDepartmentHistory, GetAllEmployeeDepartmentHistoryDto>)
                .ToList();
}
}
}
