using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Organization
{
    public class GetByIdCompanyQuery : IRequest<GetByIdCompanyDto?>
    {
        public Guid Id { get; set; }

        public GetByIdCompanyQuery(Guid id)
        {
            Id = id;
        }
    }
}
