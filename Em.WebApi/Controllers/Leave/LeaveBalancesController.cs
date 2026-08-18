using Em.Core.Application.CQRS.Leave.Commands;
using Em.Core.Application.CQRS.Leave.Queries;
using Em.Core.Application.DTOs.CreateDtos.Leave;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Application.DTOs.UpdateDtos.Leave;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Leave
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveBalancesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveBalancesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllLeaveBalanceDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllLeaveBalanceQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdLeaveBalanceDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdLeaveBalanceQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateLeaveBalanceDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateLeaveBalanceCommand { CreateLeaveBalanceDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLeaveBalanceDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateLeaveBalanceCommand { UpdateLeaveBalanceDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteLeaveBalanceCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
