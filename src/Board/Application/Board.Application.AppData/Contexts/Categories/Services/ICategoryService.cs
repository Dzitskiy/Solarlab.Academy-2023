using Board.Contracts.Category;

namespace Board.Application.AppData.Contexts.Categories.Services
{
    /// <summary>
    /// Сервис для работы с категориями.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Создание категории.
        /// </summary>
        /// <param name="model">Модель категории.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Идентификатор созданной категории.</returns>
        Task<Guid> CreateAsync(CreateCategoryDto model, CancellationToken cancellationToken);

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
        Task<CategoryInfoDto[]> GetActiveAsync(CancellationToken cancellationToken);
    }
}
