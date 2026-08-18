using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetByIdUserRoleQueryHandler : IRequestHandler<GetByIdUserRoleQuery, GetByIdUserRoleDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdUserRoleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdUserRoleDto?> Handle(GetByIdUserRoleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserRoleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<UserRole, GetByIdUserRoleDto>(entity);
}
}
}
