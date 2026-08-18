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
    public class AttendanceRecordsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendanceRecordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllAttendanceRecordDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllAttendanceRecordQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdAttendanceRecordDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdAttendanceRecordQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAttendanceRecordDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateAttendanceRecordCommand { CreateAttendanceRecordDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAttendanceRecordDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateAttendanceRecordCommand { UpdateAttendanceRecordDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAttendanceRecordCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
