using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, IReadOnlyList<GetAllRoleDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRoleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllRoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.RoleRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Role, GetAllRoleDto>)
                .ToList();
}
}
}
