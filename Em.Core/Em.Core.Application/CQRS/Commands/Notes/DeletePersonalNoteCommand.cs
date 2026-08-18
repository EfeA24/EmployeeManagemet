using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notes
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
