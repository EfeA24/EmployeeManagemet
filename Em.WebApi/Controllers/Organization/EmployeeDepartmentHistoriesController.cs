using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.DTOs.CreateDtos.Organization;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Organization
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeDepartmentHistoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeDepartmentHistoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllEmployeeDepartmentHistoryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllEmployeeDepartmentHistoryQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdEmployeeDepartmentHistoryDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdEmployeeDepartmentHistoryQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeDepartmentHistoryDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateEmployeeDepartmentHistoryCommand { CreateEmployeeDepartmentHistoryDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDepartmentHistoryDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateEmployeeDepartmentHistoryCommand { UpdateEmployeeDepartmentHistoryDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteEmployeeDepartmentHistoryCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
