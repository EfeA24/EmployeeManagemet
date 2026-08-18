using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllAssetRequestTicketQueryHandler : IRequestHandler<GetAllAssetRequestTicketQuery, IReadOnlyList<GetAllAssetRequestTicketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAssetRequestTicketQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllAssetRequestTicketDto>> Handle(GetAllAssetRequestTicketQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.AssetRequestTicketRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AssetRequestTicket, GetAllAssetRequestTicketDto>)
                .ToList();
}
}
}
