using MediatR;
using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
{
    public class GetAllAttendanceRecordQueryHandler : IRequestHandler<GetAllAttendanceRecordQuery, IReadOnlyList<GetAllAttendanceRecordDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAttendanceRecordQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllAttendanceRecordDto>> Handle(GetAllAttendanceRecordQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.AttendanceRecordRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AttendanceRecord, GetAllAttendanceRecordDto>)
                .ToList();
}
}
}
