using Em.Core.Application.CQRS.Commands.Audit;
using Em.Core.Application.CQRS.Queries.Audit;
using Em.Core.Application.DTOs.CreateDtos.Audit;
using Em.Core.Application.DTOs.ReadDtos.Audit;
using Em.Core.Application.DTOs.UpdateDtos.Audit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Audit
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuditLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllAuditLogDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllAuditLogQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdAuditLogDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdAuditLogQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAuditLogDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateAuditLogCommand { CreateAuditLogDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuditLogDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateAuditLogCommand { UpdateAuditLogDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAuditLogCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
