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
    public class TicketAttachmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketAttachmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllTicketAttachmentDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllTicketAttachmentQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdTicketAttachmentDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdTicketAttachmentQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTicketAttachmentDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateTicketAttachmentCommand { CreateTicketAttachmentDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTicketAttachmentDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateTicketAttachmentCommand { UpdateTicketAttachmentDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTicketAttachmentCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
