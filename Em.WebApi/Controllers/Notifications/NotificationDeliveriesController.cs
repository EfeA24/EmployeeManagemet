using Em.Core.Application.CQRS.Notifications.Commands;
using Em.Core.Application.CQRS.Notifications.Queries;
using Em.Core.Application.DTOs.CreateDtos.Notifications;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.DTOs.UpdateDtos.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Notifications
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationDeliveriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationDeliveriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllNotificationDeliveryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllNotificationDeliveryQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdNotificationDeliveryDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdNotificationDeliveryQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNotificationDeliveryDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateNotificationDeliveryCommand { CreateNotificationDeliveryDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNotificationDeliveryDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateNotificationDeliveryCommand { UpdateNotificationDeliveryDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteNotificationDeliveryCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
