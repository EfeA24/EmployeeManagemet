using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllGeneralTicketQueryHandler : IRequestHandler<GetAllGeneralTicketQuery, IReadOnlyList<GetAllGeneralTicketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGeneralTicketQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllGeneralTicketDto>> Handle(GetAllGeneralTicketQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.GeneralTicketRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<GeneralTicket, GetAllGeneralTicketDto>)
                .ToList();
}
}
}
