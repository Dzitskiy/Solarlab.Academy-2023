using Board.Application.AppData.Contexts.Adverts.Repositories;
using Board.Contracts.Advert;
using Board.Domain.Adverts;
using Board.Infrastucture.Repository;

namespace Board.Infrastucture.DataAccess.Contexts.Posts.Repository;

public class AdvertRepository : IAdvertRepository
{
    private readonly IRepository<Advert> _advertRepository;

    public AdvertRepository(IRepository<Advert> advertRepository)
    {
        _advertRepository = advertRepository;
    }

    /// <summary>
    /// TODO: Подлежит рефактору. Не использовать!
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<CreateAdvertDto> AddAdvert(Advert entity)
    {
        var result = _advertRepository.AddAsync(entity);
        return Task.Run(() => new CreateAdvertDto());
    }
}