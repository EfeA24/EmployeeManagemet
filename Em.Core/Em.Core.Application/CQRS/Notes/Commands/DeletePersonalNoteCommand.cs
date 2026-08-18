using MediatR;

namespace Em.Core.Application.CQRS.Notes.Commands
{
    public class DeletePersonalNoteCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeletePersonalNoteCommand(Guid id)
        {
            Id = id;
        }
    }
}
