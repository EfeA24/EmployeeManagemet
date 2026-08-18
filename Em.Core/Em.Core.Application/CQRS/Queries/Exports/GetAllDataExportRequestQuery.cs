using Em.Core.Application.DTOs.ReadDtos.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Exports
{
    public class GetAllDataExportRequestQuery : IRequest<IReadOnlyList<GetAllDataExportRequestDto>>
    {
    }
}
