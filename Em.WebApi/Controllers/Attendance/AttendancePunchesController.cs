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
    public class AttendancePunchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendancePunchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllAttendancePunchDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllAttendancePunchQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdAttendancePunchDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdAttendancePunchQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAttendancePunchDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateAttendancePunchCommand { CreateAttendancePunchDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAttendancePunchDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateAttendancePunchCommand { UpdateAttendancePunchDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAttendancePunchCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
