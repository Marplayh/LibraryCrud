using LibraryCrud.Entities.interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.JsonPatch;

namespace LibraryCrud.Services.interfaces.shared
{
    public interface ICrudService<TEntity> where TEntity : class, IEntity
    {
        Task Post(TEntity entity, bool saveChanges = true);
        Task Post(TEntity entity);
        Task Put(TEntity entity);
        Task Delete(Guid entity);
        Task Delete(TEntity entity);
        Task SaveChangesAsync();
        void Modified(TEntity entity);
        IDbContextTransaction BeginTransaction();
    }
}