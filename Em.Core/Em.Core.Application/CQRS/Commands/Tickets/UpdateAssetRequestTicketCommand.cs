using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class UpdateAssetRequestTicketCommand : IRequest
    {
        public UpdateAssetRequestTicketDto UpdateAssetRequestTicketDto { get; set; } = null!;
    }
}
