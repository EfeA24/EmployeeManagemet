using Em.Core.Application.CQRS.Exports.Commands;
using Em.Core.Application.CQRS.Exports.Queries;
using Em.Core.Application.DTOs.CreateDtos.Exports;
using Em.Core.Application.DTOs.ReadDtos.Exports;
using Em.Core.Application.DTOs.UpdateDtos.Exports;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Exports
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataExportRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DataExportRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllDataExportRequestDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllDataExportRequestQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdDataExportRequestDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdDataExportRequestQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDataExportRequestDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateDataExportRequestCommand { CreateDataExportRequestDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDataExportRequestDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateDataExportRequestCommand { UpdateDataExportRequestDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteDataExportRequestCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
