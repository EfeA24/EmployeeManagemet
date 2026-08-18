using Em.Core.Application.Interfaces.Repositories.NotesRepositories;
using Em.Core.Domain.Entities.Notes;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.NotesRepositories
{
    public class PersonalNoteRepository : GenericRepository<PersonalNote>, IPersonalNoteRepository
    {
        public PersonalNoteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
