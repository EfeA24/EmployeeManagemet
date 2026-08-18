using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.CQRS.Tickets.Queries;
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
    public class GeneralTicketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GeneralTicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllGeneralTicketDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllGeneralTicketQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdGeneralTicketDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdGeneralTicketQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGeneralTicketDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateGeneralTicketCommand { CreateGeneralTicketDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGeneralTicketDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateGeneralTicketCommand { UpdateGeneralTicketDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteGeneralTicketCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
