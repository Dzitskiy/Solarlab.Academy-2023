using Board.Contracts.Advert;
using Board.Domain.Advert;

namespace Board.Application.AppData.Contexts.Adverts.Repositories;

public interface IAdvertRepository
{
    Task<CreateAdvertDto> AddAdvert(Advert entity);
}