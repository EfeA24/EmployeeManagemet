using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class UpdateAttendanceCorrectionCommandHandler : IRequestHandler<UpdateAttendanceCorrectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAttendanceCorrectionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAttendanceCorrectionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceCorrectionRepository.GetByIdAsync(request.UpdateAttendanceCorrectionDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAttendanceCorrectionDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendanceCorrectionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
