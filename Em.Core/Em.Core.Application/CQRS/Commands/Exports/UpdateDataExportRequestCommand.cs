using Em.Core.Application.DTOs.UpdateDtos.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Exports
{
    public class UpdateDataExportRequestCommand : IRequest
    {
        public UpdateDataExportRequestDto UpdateDataExportRequestDto { get; set; } = null!;
    }
}
