using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class CreateAssetRequestTicketCommand : IRequest<Guid>
    {
        public CreateAssetRequestTicketDto CreateAssetRequestTicketDto { get; set; } = null!;
    }
}
