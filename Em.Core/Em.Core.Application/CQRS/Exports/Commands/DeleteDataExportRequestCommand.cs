using MediatR;

namespace Em.Core.Application.CQRS.Exports.Commands
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
