using Em.Core.Application.DTOs.ReadDtos.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Exports.Queries
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
