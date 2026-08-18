using Em.Core.Application.CQRS.Organization.Commands;
using Em.Core.Application.CQRS.Organization.Queries;
using Em.Core.Application.DTOs.CreateDtos.Organization;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Organization
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionPeriodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionPeriodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllSubscriptionPeriodDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllSubscriptionPeriodQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdSubscriptionPeriodDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdSubscriptionPeriodQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSubscriptionPeriodDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateSubscriptionPeriodCommand { CreateSubscriptionPeriodDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubscriptionPeriodDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateSubscriptionPeriodCommand { UpdateSubscriptionPeriodDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteSubscriptionPeriodCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
