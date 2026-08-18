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
    public class DeviceTokensController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceTokensController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllDeviceTokenDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllDeviceTokenQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdDeviceTokenDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdDeviceTokenQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDeviceTokenDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateDeviceTokenCommand { CreateDeviceTokenDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDeviceTokenDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateDeviceTokenCommand { UpdateDeviceTokenDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteDeviceTokenCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
