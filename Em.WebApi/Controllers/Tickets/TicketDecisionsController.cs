using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.DTOs.CreateDtos.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Tickets
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketDecisionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketDecisionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllTicketDecisionDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllTicketDecisionQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdTicketDecisionDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdTicketDecisionQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTicketDecisionDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateTicketDecisionCommand { CreateTicketDecisionDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTicketDecisionDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateTicketDecisionCommand { UpdateTicketDecisionDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTicketDecisionCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
