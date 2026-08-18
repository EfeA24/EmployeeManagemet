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
    public class ApprovalDelegationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApprovalDelegationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllApprovalDelegationDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllApprovalDelegationQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdApprovalDelegationDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdApprovalDelegationQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateApprovalDelegationDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateApprovalDelegationCommand { CreateApprovalDelegationDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateApprovalDelegationDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateApprovalDelegationCommand { UpdateApprovalDelegationDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteApprovalDelegationCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
