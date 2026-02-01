using LibraryCrud.Services.interfaces;
using LibraryCrud.Services.shared;
using LibraryCrud.Entities;
using LibraryCrud.repository;
using LibraryCrud.repository.interfaces;

namespace LibraryCrud.Services
{
    public class LibraryService : CrudService<Library, ILibraryRepository>, ILibraryService
    {
        private readonly ILibraryRepository _repository;

        public LibraryService(ILibraryRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}