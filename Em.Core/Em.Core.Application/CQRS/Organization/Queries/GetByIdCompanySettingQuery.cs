using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
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
