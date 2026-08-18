using Em.Core.Application.DTOs.CreateDtos.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Notes.Commands
{
    public class CreatePersonalNoteCommand : IRequest<Guid>
    {
        public CreatePersonalNoteDto CreatePersonalNoteDto { get; set; } = null!;
    }
}
