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
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllCompanyDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllCompanyQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdCompanyDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdCompanyQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCompanyDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateCompanyCommand { CreateCompanyDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateCompanyCommand { UpdateCompanyDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCompanyCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
