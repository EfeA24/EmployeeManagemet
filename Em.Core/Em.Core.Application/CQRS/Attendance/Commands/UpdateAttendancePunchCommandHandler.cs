using Em.Core.Application.CQRS.Attendance.Commands;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class UpdateAttendancePunchCommandHandler : IRequestHandler<UpdateAttendancePunchCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateAttendancePunchCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateAttendancePunchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendancePunchRepository.GetByIdAsync(request.UpdateAttendancePunchDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAttendancePunchDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendancePunchRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<AttendancePunch, GetByIdAttendancePunchDto>(entity);
            await _cache.SetAsync($"AttendancePunch:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
