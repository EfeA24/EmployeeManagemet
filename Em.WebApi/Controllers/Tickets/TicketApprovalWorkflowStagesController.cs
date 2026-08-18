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
    public class TicketApprovalWorkflowStagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketApprovalWorkflowStagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllTicketApprovalWorkflowStageDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllTicketApprovalWorkflowStageQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdTicketApprovalWorkflowStageDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdTicketApprovalWorkflowStageQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTicketApprovalWorkflowStageDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateTicketApprovalWorkflowStageCommand { CreateTicketApprovalWorkflowStageDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTicketApprovalWorkflowStageDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateTicketApprovalWorkflowStageCommand { UpdateTicketApprovalWorkflowStageDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTicketApprovalWorkflowStageCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
