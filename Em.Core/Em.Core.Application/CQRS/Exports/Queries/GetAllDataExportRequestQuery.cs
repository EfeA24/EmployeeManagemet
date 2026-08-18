using Em.Core.Application.DTOs.ReadDtos.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Exports.Queries
{
    public class GetAllDataExportRequestQuery : IRequest<IReadOnlyList<GetAllDataExportRequestDto>>
    {
    }
}
