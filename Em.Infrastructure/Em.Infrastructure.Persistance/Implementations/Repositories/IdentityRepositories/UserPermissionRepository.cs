using Em.Core.Application.Interfaces.Repositories.IdentityRepositories;
using Em.Core.Domain.Entities.Identity;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.IdentityRepositories
{
    public class UserPermissionRepository : GenericRepository<UserPermission>, IUserPermissionRepository
    {
        public UserPermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
