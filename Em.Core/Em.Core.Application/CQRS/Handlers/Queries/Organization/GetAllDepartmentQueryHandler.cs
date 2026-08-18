using MediatR;
using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Domain.Entities.Organization;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, IReadOnlyList<GetAllDepartmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDepartmentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllDepartmentDto>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.DepartmentRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Department, GetAllDepartmentDto>)
                .ToList();
}
}
}
