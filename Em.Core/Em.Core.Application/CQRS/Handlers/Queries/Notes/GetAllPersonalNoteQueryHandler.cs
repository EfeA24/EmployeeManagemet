using Em.Core.Application.CQRS.Queries.Notes;
using Em.Core.Application.DTOs.ReadDtos.Notes;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notes
{
    public class GetAllPersonalNoteQueryHandler : IRequestHandler<GetAllPersonalNoteQuery, IReadOnlyList<GetAllPersonalNoteDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllPersonalNoteQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllPersonalNoteDto>> Handle(GetAllPersonalNoteQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<PersonalNote>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
