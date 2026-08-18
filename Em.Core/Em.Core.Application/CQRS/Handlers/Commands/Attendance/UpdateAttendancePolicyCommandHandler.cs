using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class UpdateAttendancePolicyCommandHandler : IRequestHandler<UpdateAttendancePolicyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAttendancePolicyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAttendancePolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendencePolicyRepository.GetByIdAsync(request.UpdateAttendancePolicyDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAttendancePolicyDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendencePolicyRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
