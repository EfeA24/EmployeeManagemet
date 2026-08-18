using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetByIdPermissionQueryHandler : IRequestHandler<GetByIdPermissionQuery, GetByIdPermissionDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdPermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdPermissionDto?> Handle(GetByIdPermissionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Permission, GetByIdPermissionDto>(entity);
}
}
}
