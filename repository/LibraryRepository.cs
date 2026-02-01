using LibraryCrud.repository.shared;
using LibraryCrud.Entities;
using LibraryCrud.repository.interfaces;

namespace LibraryCrud.repository
{
    public class LibraryRepository : CrudRepository<AppDbContext, Library>, ILibraryRepository
    {
        public LibraryRepository(AppDbContext context) : base(context)
        {
        }
    }
}