using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQuery, GetByIdRoleDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdRoleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdRoleDto?> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.RoleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Role, GetByIdRoleDto>(entity);
}
}
}
