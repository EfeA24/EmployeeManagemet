using Em.Core.Application.Interfaces.Repositories.ExportRepositories;
using Em.Core.Domain.Entities.Exports;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.ExportRepositories
{
    public class DataExportRequestRepository : GenericRepository<DataExportRequest>, IDataExportRequestRepository
    {
        public DataExportRequestRepository(AppDbContext context) : base(context)
        {
        }
    }
}
