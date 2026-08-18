using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetAllUserPermissionQueryHandler : IRequestHandler<GetAllUserPermissionQuery, IReadOnlyList<GetAllUserPermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserPermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllUserPermissionDto>> Handle(GetAllUserPermissionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.UserPermissionRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<UserPermission, GetAllUserPermissionDto>)
                .ToList();
}
}
}
