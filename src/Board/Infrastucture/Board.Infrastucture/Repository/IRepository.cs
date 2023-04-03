using System.Linq.Expressions;

namespace Board.Infrastucture.Repository;

/// <summary>
/// Базовый репозиторий.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity: class
{
    /// <summary>
    /// Возвращает все элементы сущности <see cref="TEntity"/>.
    /// </summary>
    /// <returns>Все элементы сущности <see cref="TEntity"/>.</returns>
    IQueryable<TEntity> GetAll();
        
    /// <summary>
    /// Возвращает все элементы сущности <see cref="TEntity"/> по фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <returns>Все элементы сущности <see cref="TEntity"/> по фильтру.</returns>
    IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> filter);

    /// <summary>
    /// Возвращает элемент <see cref="TEntity"/> по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор <see cref="TEntity"/>.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns><see cref="TEntity"/>.</returns>
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Добавляет элемент <see cref="TEntity"/>.
    /// </summary>
    /// <param name="model">Новая сущность <see cref="TEntity"/>.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task AddAsync(TEntity model, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет элемент <see cref="TEntity"/>.
    /// </summary>
    /// <param name="model">Существующая сущность <see cref="TEntity"/>.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task UpdateAsync(TEntity model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет элемент <see cref="TEntity"/>.
    /// </summary>
    /// <param name="model">Существующая сущность <see cref="TEntity"/>.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(TEntity model, CancellationToken cancellationToken);
}