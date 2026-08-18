using Em.Core.Application.CQRS.Identity.Queries;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IReadOnlyList<GetAllUserDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllUserQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllUserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<User>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<User, GetAllUserDto>)
                .ToList();
        }
    }
}
