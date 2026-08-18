using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Organization
{
    public class GetByIdCompanySettingQuery : IRequest<GetByIdCompanySettingDto?>
    {
        public Guid Id { get; set; }

        public GetByIdCompanySettingQuery(Guid id)
        {
            Id = id;
        }
    }
}
