using Em.Core.Application.CQRS.Attendance.Commands;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class UpdateAttendanceCorrectionCommandHandler : IRequestHandler<UpdateAttendanceCorrectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateAttendanceCorrectionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
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

            var cached = DtoMapper.Map<AttendanceCorrection, GetByIdAttendanceCorrectionDto>(entity);
            await _cache.SetAsync($"AttendanceCorrection:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
