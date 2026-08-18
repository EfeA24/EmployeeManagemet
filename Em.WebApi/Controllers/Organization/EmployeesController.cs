using Em.Core.Application.CQRS.Organization.Commands;
using Em.Core.Application.CQRS.Organization.Queries;
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
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllEmployeeDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllEmployeeQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdEmployeeDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdEmployeeQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateEmployeeCommand { CreateEmployeeDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateEmployeeCommand { UpdateEmployeeDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteEmployeeCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
