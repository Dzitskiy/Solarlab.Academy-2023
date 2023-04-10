using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Contexts.Adverts.Repositories;
using Board.Contracts.Advert;
using Board.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.Advert.Repository;

using Advert = Domain.Adverts.Advert;

/// <inheritdoc cref="IAdvertRepository"/>
public class AdvertRepository : IAdvertRepository
{
    private readonly IRepository<Advert> _repository;
    private readonly IMapper _mapper;

    public AdvertRepository(IRepository<Advert> advertRepository, IMapper mapper)
    {
        _repository = advertRepository;
        _mapper = mapper;
    }

    public Task<AdvertShortInfoDto[]> GetAll(CancellationToken cancellationToken)
    {
        return _repository.GetAll().Where(s => s.IsActive)
            .ProjectTo<AdvertShortInfoDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }

    public Task<AdvertInfoDto> Get(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetAll()
            .ProjectTo<AdvertInfoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<AdvertInfoDto> Add(Advert entity, CancellationToken cancellationToken)
    {
        entity.Created = DateTime.UtcNow;
        await _repository.AddAsync(entity, cancellationToken);
        return _mapper.Map<AdvertInfoDto>(entity);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return;
        }

        await _repository.DeleteAsync(entity, cancellationToken);
    }
}