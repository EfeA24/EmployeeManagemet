using MediatR;
using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IReadOnlyList<GetAllUserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllUserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.UserRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<User, GetAllUserDto>)
                .ToList();
}
}
}
