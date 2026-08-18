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
    public class TicketApprovalPermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketApprovalPermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllTicketApprovalPermissionDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllTicketApprovalPermissionQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdTicketApprovalPermissionDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdTicketApprovalPermissionQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTicketApprovalPermissionDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateTicketApprovalPermissionCommand { CreateTicketApprovalPermissionDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTicketApprovalPermissionDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateTicketApprovalPermissionCommand { UpdateTicketApprovalPermissionDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTicketApprovalPermissionCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
