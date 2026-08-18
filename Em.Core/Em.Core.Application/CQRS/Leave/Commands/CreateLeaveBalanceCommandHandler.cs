using Em.Core.Application.CQRS.Leave.Commands;
using Em.Core.Application.DTOs.CreateDtos.Leave;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Commands
{
    public class CreateLeaveBalanceCommandHandler : IRequestHandler<CreateLeaveBalanceCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateLeaveBalanceCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateLeaveBalanceDto, LeaveBalance>(request.CreateLeaveBalanceDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.LeaveBalanceRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<LeaveBalance, GetByIdLeaveBalanceDto>(entity);
            await _cache.SetAsync($"LeaveBalance:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
