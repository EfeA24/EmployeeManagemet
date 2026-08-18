using MediatR;
using Em.Core.Application.CQRS.Queries.Notes;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Notes;
using Em.Core.Domain.Entities.Notes;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notes
{
    public class GetAllPersonalNoteQueryHandler : IRequestHandler<GetAllPersonalNoteQuery, IReadOnlyList<GetAllPersonalNoteDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPersonalNoteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllPersonalNoteDto>> Handle(GetAllPersonalNoteQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.PersonalNoteRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<PersonalNote, GetAllPersonalNoteDto>)
                .ToList();
}
}
}
