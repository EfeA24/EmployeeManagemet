using MediatR;
using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Domain.Entities.Organization;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IReadOnlyList<GetAllEmployeeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllEmployeeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllEmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.EmployeeRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Employee, GetAllEmployeeDto>)
                .ToList();
}
}
}
