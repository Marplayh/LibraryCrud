using LibraryCrud.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using LibraryCrud.Entities;

namespace LibraryCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : MasterCrudController<Library>
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService, ILogger<LibraryController> logger) : base(logger,libraryService)
        {
            _libraryService = libraryService;
        }

        public override Task<ActionResult<Library>> Post([FromBody] Library model)
        {
            return base.Post(model);
        }
    }
}