using Board.Contracts.Advert;
using Board.Domain.Adverts;

namespace Board.Application.AppData.Contexts.Adverts.Repositories;

public interface IAdvertRepository
{
    Task<CreateAdvertDto> AddAdvert(Advert entity);
}