using Em.Core.Application.CQRS.Notes.Queries;
using Em.Core.Application.DTOs.ReadDtos.Notes;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Notes.Queries
{
    public class GetByIdPersonalNoteQueryHandler : IRequestHandler<GetByIdPersonalNoteQuery, GetByIdPersonalNoteDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdPersonalNoteQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdPersonalNoteDto?> Handle(GetByIdPersonalNoteQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<PersonalNote>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<PersonalNote, GetByIdPersonalNoteDto>(entity);
        }
    }
}
