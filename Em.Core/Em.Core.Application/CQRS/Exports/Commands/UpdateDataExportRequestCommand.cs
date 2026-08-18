using Em.Core.Application.DTOs.UpdateDtos.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Exports.Commands
{
    public class UpdateDataExportRequestCommand : IRequest
    {
        public UpdateDataExportRequestDto UpdateDataExportRequestDto { get; set; } = null!;
    }
}
