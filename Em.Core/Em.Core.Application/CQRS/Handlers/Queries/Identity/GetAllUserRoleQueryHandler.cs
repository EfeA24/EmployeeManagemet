using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetAllUserRoleQueryHandler : IRequestHandler<GetAllUserRoleQuery, IReadOnlyList<GetAllUserRoleDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserRoleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllUserRoleDto>> Handle(GetAllUserRoleQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.UserRoleRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<UserRole, GetAllUserRoleDto>)
                .ToList();
}
}
}
