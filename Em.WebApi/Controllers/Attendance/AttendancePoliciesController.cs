using Em.Core.Application.CQRS.Attendance.Commands;
using Em.Core.Application.CQRS.Attendance.Queries;
using Em.Core.Application.DTOs.CreateDtos.Attendance;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.DTOs.UpdateDtos.Attendance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Attendance
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendancePoliciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendancePoliciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllAttendancePolicyDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllAttendancePolicyQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdAttendancePolicyDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdAttendancePolicyQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAttendancePolicyDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateAttendancePolicyCommand { CreateAttendancePolicyDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAttendancePolicyDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateAttendancePolicyCommand { UpdateAttendancePolicyDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAttendancePolicyCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
