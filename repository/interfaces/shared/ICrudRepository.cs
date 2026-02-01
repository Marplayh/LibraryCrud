using Microsoft.EntityFrameworkCore.Storage;

namespace LibraryCrud.repository.interfaces.shared
{
    public interface ICrudRepository<TEntity>
    {
        IQueryable<TEntity> GetAllTracking(string include = "");
        IQueryable<TEntity> GetAllNoTracking(string include = "");
        Task<TEntity> GetByIdNoTracking(Guid id, string include = "");
        Task<TEntity> GetByIdAsyncTracking(Guid id, string include = "");
        IDbContextTransaction BeginTransaction();
        Task Insert(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Detached(TEntity entity);
        void Modified(TEntity entity);
        Task SaveChangesAsync();
    }
}