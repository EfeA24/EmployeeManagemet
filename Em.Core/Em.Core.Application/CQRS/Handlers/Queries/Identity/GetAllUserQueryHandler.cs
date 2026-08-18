using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
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
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
