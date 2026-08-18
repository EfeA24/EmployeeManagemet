using Em.Core.Application.DTOs.CreateDtos.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notes
{
    public class CreatePersonalNoteCommand : IRequest<Guid>
    {
        public CreatePersonalNoteDto CreatePersonalNoteDto { get; set; } = null!;
    }
}
