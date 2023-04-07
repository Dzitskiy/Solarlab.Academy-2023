using Board.Contracts.Advert;

namespace Board.Application.AppData.Contexts.Adverts.Services;

/// <summary>
/// Сервис для работы с объявлениями.
/// </summary>
public interface IAdvertService
{
    /// <summary>
    /// Получить список объявлений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список объявлений.</returns>
    Task<AdvertShortInfoDto[]> GetAll(CancellationToken cancellationToken);

    /// <summary>
    /// Получить объявление по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель объявления.</returns>
    Task<AdvertInfoDto> Get(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Создает объявление.
    /// </summary>
    /// <param name="dto">Модель создания объявления.</param>
    /// <param name="cancellation">Токен отмены операции.</param>
    /// <returns>Модель созданного объявления.</returns>
    Task<AdvertInfoDto> Add(CreateAdvertDto dto, CancellationToken cancellation);

    /// <summary>
    /// Удалить объявление.
    /// </summary>
    /// <param name="id">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    Task Delete(Guid id, CancellationToken cancellationToken);
}