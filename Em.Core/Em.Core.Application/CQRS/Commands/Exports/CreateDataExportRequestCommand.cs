using Em.Core.Application.DTOs.CreateDtos.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Exports
{
    public class CreateDataExportRequestCommand : IRequest<Guid>
    {
        public CreateDataExportRequestDto CreateDataExportRequestDto { get; set; } = null!;
    }
}
