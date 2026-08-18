using Em.Core.Application.Interfaces.Repositories.OrganizationRepositories;
using Em.Core.Domain.Entities.Organization;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.OrganizationRepositories
{
    public class CompanySettingRepository : GenericRepository<CompanySetting>, ICompanySettingRepository
    {
        public CompanySettingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
