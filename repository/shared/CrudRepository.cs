using LibraryCrud.repository.interfaces.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using LibraryCrud.Entities.interfaces;

namespace LibraryCrud.repository.shared
{
    public class CrudRepository<TContext, TEntity> : ICrudRepository<TEntity> where TContext : DbContext 
        where TEntity : class, IEntity
    {
        private readonly TContext _context;
        public CrudRepository(TContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAllTracking(string include = "")
        {
            return  SetInclude(_context.Set<TEntity>(), include);
        }

        public IQueryable<TEntity> GetAllNoTracking(string include = "")
        {
            return  SetInclude(_context.Set<TEntity>().AsNoTracking(), include);
        }

        public virtual async Task<TEntity> GetByIdNoTracking(Guid id, string include = "")
        {
            return await SetInclude(_context.Set<TEntity>().AsNoTracking(), include).SingleOrDefaultAsync(x => x.Id.Equals(id));

        }
        public virtual async Task<TEntity> GetByIdAsyncTracking(Guid id, string include = "")
        {
            return await SetInclude(_context.Set<TEntity>(), include).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task Insert(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Detached(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public void Modified(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {

            await _context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public IQueryable<TEntity> SetInclude(IQueryable<TEntity> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }
    }
}