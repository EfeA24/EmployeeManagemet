using MediatR;
using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
{
    public class GetAllAttendanceViolationQueryHandler : IRequestHandler<GetAllAttendanceViolationQuery, IReadOnlyList<GetAllAttendanceViolationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAttendanceViolationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllAttendanceViolationDto>> Handle(GetAllAttendanceViolationQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.AttendanceViolationRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AttendanceViolation, GetAllAttendanceViolationDto>)
                .ToList();
}
}
}
