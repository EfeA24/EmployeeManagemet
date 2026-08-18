using Em.Core.Application.CQRS.Notes.Commands;
using Em.Core.Application.CQRS.Notes.Queries;
using Em.Core.Application.DTOs.CreateDtos.Notes;
using Em.Core.Application.DTOs.ReadDtos.Notes;
using Em.Core.Application.DTOs.UpdateDtos.Notes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Em.WebApi.Controllers.Notes
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalNotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonalNotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<GetAllPersonalNoteDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetAllPersonalNoteQuery(), cancellationToken);
            return Ok(items.AsQueryable());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetByIdPersonalNoteDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetByIdPersonalNoteQuery(id), cancellationToken);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePersonalNoteDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreatePersonalNoteCommand { CreatePersonalNoteDto = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePersonalNoteDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdatePersonalNoteCommand { UpdatePersonalNoteDto = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeletePersonalNoteCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
