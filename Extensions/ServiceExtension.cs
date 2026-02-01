using LibraryCrud.repository;
using LibraryCrud.repository.interfaces;
using LibraryCrud.repository.interfaces.shared;
using LibraryCrud.Services;
using LibraryCrud.Services.interfaces;

namespace LibraryCrud.Extensions
{
    public static class ServiceExtension
    {
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddTransient<ILibraryService, LibraryService>();
        }
    }
}