using MediatR;
using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
{
    public class GetAllAttendancePolicyQueryHandler : IRequestHandler<GetAllAttendancePolicyQuery, IReadOnlyList<GetAllAttendancePolicyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAttendancePolicyQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllAttendancePolicyDto>> Handle(GetAllAttendancePolicyQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.AttendencePolicyRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AttendancePolicy, GetAllAttendancePolicyDto>)
                .ToList();
}
}
}
