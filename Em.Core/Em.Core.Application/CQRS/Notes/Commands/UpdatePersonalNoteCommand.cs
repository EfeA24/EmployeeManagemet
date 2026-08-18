using Em.Core.Application.DTOs.UpdateDtos.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Notes.Commands
{
    public class UpdatePersonalNoteCommand : IRequest
    {
        public UpdatePersonalNoteDto UpdatePersonalNoteDto { get; set; } = null!;
    }
}
