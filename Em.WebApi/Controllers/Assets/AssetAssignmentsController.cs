using Em.Core.Application.CQRS.Commands.Assets;
using Em.Core.Application.CQRS.Queries.Assets;
using Em.Core.Application.DTOs.CreateDtos.Assets;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Application.DTOs.UpdateDtos.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Assets
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetAssignmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssetAssignmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllAssetAssignmentDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllAssetAssignmentQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdAssetAssignmentDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdAssetAssignmentQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAssetAssignmentDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateAssetAssignmentCommand { CreateAssetAssignmentDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAssetAssignmentDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateAssetAssignmentCommand { UpdateAssetAssignmentDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAssetAssignmentCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
