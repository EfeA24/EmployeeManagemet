using Em.Core.Application.DTOs.CreateDtos.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Exports.Commands
{
    public class CreateDataExportRequestCommand : IRequest<Guid>
    {
        public CreateDataExportRequestDto CreateDataExportRequestDto { get; set; } = null!;
    }
}
