using MediatR;
using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Domain.Entities.Organization;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQuery, GetByIdEmployeeDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdEmployeeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdEmployeeDto?> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Employee, GetByIdEmployeeDto>(entity);
}
}
}
