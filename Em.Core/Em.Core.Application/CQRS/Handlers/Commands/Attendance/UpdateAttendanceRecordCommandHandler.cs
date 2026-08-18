using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class UpdateAttendanceRecordCommandHandler : IRequestHandler<UpdateAttendanceRecordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAttendanceRecordCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAttendanceRecordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceRecordRepository.GetByIdAsync(request.UpdateAttendanceRecordDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAttendanceRecordDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendanceRecordRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
