using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetByIdRolePermissionQueryHandler : IRequestHandler<GetByIdRolePermissionQuery, GetByIdRolePermissionDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdRolePermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdRolePermissionDto?> Handle(GetByIdRolePermissionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.RolePermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<RolePermission, GetByIdRolePermissionDto>(entity);
}
}
}
