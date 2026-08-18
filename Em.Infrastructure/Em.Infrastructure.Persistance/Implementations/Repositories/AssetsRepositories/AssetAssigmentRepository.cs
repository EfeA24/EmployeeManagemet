using Em.Core.Application.Interfaces.Repositories.AssetsRepositories;
using Em.Core.Domain.Entities.Assets;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.AssetsRepositories
{
    public class AssetAssigmentRepository : GenericRepository<AssetAssignment>, IAssetAssigmentRepository
    {
        public AssetAssigmentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
