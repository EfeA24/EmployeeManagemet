using Em.Core.Application.CQRS.Identity.Commands;
using Em.Core.Application.CQRS.Identity.Queries;
using Em.Core.Application.DTOs.CreateDtos.Identity;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllRoleDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllRoleQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdRoleDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdRoleQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRoleDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateRoleCommand { CreateRoleDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoleDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateRoleCommand { UpdateRoleDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteRoleCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
