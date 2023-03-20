using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.Repository;

/// <inheritdoc />
public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
{
    protected DbContext DbContext { get; }
    protected DbSet<TEntity> DbSet { get; }

    /// <summary>
    /// Инициализирует экземпляр <see cref="Repository"/>.
    /// </summary>
    /// <param name="context">Контекст БД.</param>
    public Repository(DbContext context)
    {
        DbContext = context;
        DbSet = DbContext.Set<TEntity>();
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetAll()
    {
        return DbSet;
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> predicat)
    {
        if (predicat == null)
        {
            throw new ArgumentNullException(nameof(predicat));
        }
        return DbSet.Where(predicat);
    }

    /// <inheritdoc />
    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task AddAsync(TEntity model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
            
        await DbSet.AddAsync(model);
        await DbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateAsync(TEntity model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
            
        DbSet.Update(model);
        await DbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(TEntity model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
            
        DbSet.Remove(model);
        await DbContext.SaveChangesAsync();
    }
}