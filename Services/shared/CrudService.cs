using LibraryCrud.Framework.Exceptions;
using LibraryCrud.repository.interfaces.shared;
using LibraryCrud.Services.interfaces.shared;
using Microsoft.EntityFrameworkCore.Storage;
using LibraryCrud.Entities.interfaces;

namespace LibraryCrud.Services.shared
{
    public class CrudService<TEntity, TCrudRepository> : ICrudService<TEntity> where TEntity : class, IEntity where TCrudRepository : ICrudRepository<TEntity>
    {
        private readonly TCrudRepository _repository;
        public CrudService(TCrudRepository repository)
        {
           _repository = repository;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _repository.BeginTransaction();
        }
        public async virtual Task Delete(Guid entity)
        {
            TEntity entityTracked = await _repository.GetByIdAsyncTracking(entity);

            if (entityTracked == null)
                throw new NotFoundException("Registro nao encontrado!");

            await Delete(entityTracked);
        }
        public async virtual Task Delete(TEntity entity)
        {
            _repository.Remove(entity);

            await SaveChangesAsync();
        }

        public async virtual Task Post(TEntity entity, bool saveChanges = true)
        {
            await _repository.Insert(entity);

            if (saveChanges)
                await _repository.SaveChangesAsync();
        }

        public async virtual Task Post(TEntity entity)
        {
            await Post(entity, true);
        }

        public async virtual Task Put(TEntity entity)
        {
            _repository.Update(entity);

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public void Modified(TEntity entity)
        {
            _repository.Modified(entity);
        }
    }
}