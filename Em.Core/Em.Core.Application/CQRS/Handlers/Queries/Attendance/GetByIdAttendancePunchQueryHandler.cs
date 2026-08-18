using MediatR;
using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
{
    public class GetByIdAttendancePunchQueryHandler : IRequestHandler<GetByIdAttendancePunchQuery, GetByIdAttendancePunchDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdAttendancePunchQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdAttendancePunchDto?> Handle(GetByIdAttendancePunchQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendancePunchRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AttendancePunch, GetByIdAttendancePunchDto>(entity);
}
}
}
