using CorePackage.Entities;
using System.Linq.Expressions;

namespace CorePackage.Repositories;

public interface IRepository<TEntity,TId> where TEntity : Entity<TId>
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
   // TEntity? GetById(TId id);
    IQueryable<TEntity> Query();

    bool Any(Expression<Func<TEntity, bool>>? filter = null,bool enableTracking = true);

    TEntity? Get(Expression<Func<TEntity, bool>> filter , bool include = true, bool enableTracking = true);
    List<TEntity> GetAll(Expression<Func<TEntity,bool>>? filter=null, bool include=true, bool enableTracking = true);

    Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken=default);

    Task<TEntity> UpdateAsync(TEntity entity,CancellationToken cancellationToken=default);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken=default);
   // Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken=default);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true, CancellationToken cancellationToken= default);

    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, bool include = true, bool enableTracking = true, CancellationToken cancellationToken= default);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool include = true, bool enableTracking = true, CancellationToken cancellationToken=default);
}
