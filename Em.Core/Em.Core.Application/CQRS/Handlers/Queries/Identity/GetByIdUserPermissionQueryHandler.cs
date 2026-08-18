using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetByIdUserPermissionQueryHandler : IRequestHandler<GetByIdUserPermissionQuery, GetByIdUserPermissionDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdUserPermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdUserPermissionDto?> Handle(GetByIdUserPermissionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserPermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<UserPermission, GetByIdUserPermissionDto>(entity);
}
}
}
