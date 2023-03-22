using Board.Contracts.Advert;
using Board.Domain.Adverts;

namespace Board.Application.AppData.Contexts.Adverts.Repositories;

/// <summary>
/// Репозиторий для работы с объявлениями.
/// </summary>
public interface IAdvertRepository
{
    Task<CreateAdvertDto> AddAdvert(Advert entity);
}