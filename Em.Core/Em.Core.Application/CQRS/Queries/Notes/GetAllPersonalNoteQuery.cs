using Em.Core.Application.DTOs.ReadDtos.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Notes
{
    public class GetAllPersonalNoteQuery : IRequest<IReadOnlyList<GetAllPersonalNoteDto>>
    {
    }
}
