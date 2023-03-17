using Board.Contracts.Advert;

namespace Board.Application.AppData.Contexts.Adverts.Services;

/// <summary>
/// Сервис для работы с объявлениями.
/// </summary>
public interface IAdvertService
{
    /// <summary>
    /// Создает объявление.
    /// </summary>
    /// <param name="dto">Модель создания объявления.</param>
    /// <param name="cancellation">Токен отмены операции.</param>
    /// <returns>Модель объявления.</returns>
    Task<AdvertInfoDto> AddAdvert(CreateAdvertDto dto, CancellationToken cancellation);
}