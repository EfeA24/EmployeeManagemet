using Em.Core.Application.CQRS.Assets.Commands;
using Em.Core.Application.CQRS.Assets.Queries;
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
    public class AssetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllAssetDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllAssetQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdAssetDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdAssetQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAssetDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateAssetCommand { CreateAssetDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAssetDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateAssetCommand { UpdateAssetDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAssetCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
