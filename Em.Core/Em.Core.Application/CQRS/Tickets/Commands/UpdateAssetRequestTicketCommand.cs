using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateAssetRequestTicketCommand : IRequest
    {
        public UpdateAssetRequestTicketDto UpdateAssetRequestTicketDto { get; set; } = null!;
    }
}
