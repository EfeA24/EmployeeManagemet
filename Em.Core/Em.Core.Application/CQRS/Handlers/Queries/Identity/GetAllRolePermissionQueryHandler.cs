using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetAllRolePermissionQueryHandler : IRequestHandler<GetAllRolePermissionQuery, IReadOnlyList<GetAllRolePermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRolePermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllRolePermissionDto>> Handle(GetAllRolePermissionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.RolePermissionRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<RolePermission, GetAllRolePermissionDto>)
                .ToList();
}
}
}
