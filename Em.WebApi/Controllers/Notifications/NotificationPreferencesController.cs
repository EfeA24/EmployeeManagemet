using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.CQRS.Queries.Notifications;
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
    public class NotificationPreferencesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationPreferencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllNotificationPreferenceDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllNotificationPreferenceQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdNotificationPreferenceDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdNotificationPreferenceQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNotificationPreferenceDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateNotificationPreferenceCommand { CreateNotificationPreferenceDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNotificationPreferenceDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateNotificationPreferenceCommand { UpdateNotificationPreferenceDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteNotificationPreferenceCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
