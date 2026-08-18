using Em.Core.Application.DTOs.ReadDtos.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Notes.Queries
{
    public class GetAllPersonalNoteQuery : IRequest<IReadOnlyList<GetAllPersonalNoteDto>>
    {
    }
}
