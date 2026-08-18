using Em.Core.Application.DTOs.ReadDtos.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Notes
{
    public class GetByIdPersonalNoteQuery : IRequest<GetByIdPersonalNoteDto?>
    {
        public Guid Id { get; set; }

        public GetByIdPersonalNoteQuery(Guid id)
        {
            Id = id;
        }
    }
}
