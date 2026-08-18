using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class UpdateEmployeeDepartmentHistoryCommandHandler : IRequestHandler<UpdateEmployeeDepartmentHistoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateEmployeeDepartmentHistoryCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateEmployeeDepartmentHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.EmployeeDepartmentHistoryRepository.GetByIdAsync(request.UpdateEmployeeDepartmentHistoryDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateEmployeeDepartmentHistoryDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.EmployeeDepartmentHistoryRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"EmployeeDepartmentHistory:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
