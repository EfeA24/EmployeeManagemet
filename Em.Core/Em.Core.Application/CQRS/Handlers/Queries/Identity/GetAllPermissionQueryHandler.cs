using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetAllPermissionQueryHandler : IRequestHandler<GetAllPermissionQuery, IReadOnlyList<GetAllPermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllPermissionDto>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.PermissionRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Permission, GetAllPermissionDto>)
                .ToList();
}
}
}
