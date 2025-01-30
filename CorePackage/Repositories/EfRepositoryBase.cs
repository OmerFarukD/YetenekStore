using CorePackage.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CorePackage.Repositories;

public abstract class EfRepositoryBase<TEntity, TId, TContext> : IRepository<TEntity, TId>

    where TEntity : Entity<TId>
    where TContext : DbContext

{


    protected  TContext Context { get; }

    protected EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public TEntity Add(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();

        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.Set<TEntity>().AddAsync(entity,cancellationToken);
        await Context.SaveChangesAsync();
        return entity;
    }

    public bool Any(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true)
    {
        // Select [] from TEntity where []  orderby [];

        IQueryable<TEntity> query = Context.Set<TEntity>();
        if (!enableTracking)
        {
            query = query.AsNoTracking();
        }

        if(filter is not null)
        {
            query = query.Where(filter);
        }

        return query.Any();



    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
        if (!enableTracking)
        {
            query = query.AsNoTracking();
        }

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        return await query.AnyAsync(cancellationToken);
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();

        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity,CancellationToken cancellationToken =default)
    {
        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> filter, bool include = true, bool enableTracking = true)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (!enableTracking)
        {
            query = query.AsNoTracking();
        }

        if (!include)
        {
            query = query.IgnoreAutoIncludes();
        }

        return query.FirstOrDefault(filter);

    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, bool include = true, bool enableTracking = true)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
        if(filter is not null)
        {
            query = query.Where(filter);
        }

        if(include is false)
        {
            query = query.IgnoreAutoIncludes();
        }
        if(enableTracking is false)
        {
            query = query.AsNoTracking();
        }

        return query.ToList();

    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool include = true, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (include is false)
        {
            query = query.IgnoreAutoIncludes();
        }
        if (enableTracking is false)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, bool include = true, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (!enableTracking)
        {
            query = query.AsNoTracking();
        }

        if (!include)
        {
            query = query.IgnoreAutoIncludes();
        }

        return await query.FirstOrDefaultAsync(filter,cancellationToken);
    }



    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity,CancellationToken cancellationToken=default)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Set<TEntity>().Update(entity);
         await  Context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
