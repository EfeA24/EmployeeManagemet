using MediatR;

namespace Em.Core.Application.CQRS.Commands.Exports
{
    public class DeleteDataExportRequestCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteDataExportRequestCommand(Guid id)
        {
            Id = id;
        }
    }
}
