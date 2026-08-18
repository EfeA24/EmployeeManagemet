using Em.Core.Application.DTOs.ReadDtos.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Exports
{
    public class GetByIdDataExportRequestQuery : IRequest<GetByIdDataExportRequestDto?>
    {
        public Guid Id { get; set; }

        public GetByIdDataExportRequestQuery(Guid id)
        {
            Id = id;
        }
    }
}
