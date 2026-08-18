using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.CQRS.Queries.Attendance;
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
    public class AttendanceViolationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendanceViolationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllAttendanceViolationDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllAttendanceViolationQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdAttendanceViolationDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdAttendanceViolationQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAttendanceViolationDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateAttendanceViolationCommand { CreateAttendanceViolationDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAttendanceViolationDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateAttendanceViolationCommand { UpdateAttendanceViolationDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAttendanceViolationCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
