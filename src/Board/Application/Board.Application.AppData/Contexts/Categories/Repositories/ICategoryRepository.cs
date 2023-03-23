using Board.Contracts.Category;
using Board.Domain.Categories;

namespace Board.Application.AppData.Contexts.Categories.Repositories
{
    /// <summary>
    /// Репозиторий для работы с категориями.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Создание категории.
        /// </summary>
        /// <param name="model">Модель категории.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Идентификатор созданной категории.</returns>
        Task<Guid> AddAsync(Category model, CancellationToken cancellationToken);

        /// <summary>
        /// Получение по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор категории.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Информация о категории.</returns>
        Task<CategoryInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получение списка активных категорий.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Список активных категорий.</returns>
        Task<List<Category>> GetActiveAsync(CancellationToken cancellationToken);
    }
}
