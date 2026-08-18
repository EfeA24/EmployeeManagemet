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
    public class TicketActionHistoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketActionHistoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllTicketActionHistoryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllTicketActionHistoryQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdTicketActionHistoryDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdTicketActionHistoryQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTicketActionHistoryDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateTicketActionHistoryCommand { CreateTicketActionHistoryDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTicketActionHistoryDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateTicketActionHistoryCommand { UpdateTicketActionHistoryDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTicketActionHistoryCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
