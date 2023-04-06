using AutoMapper;
using Board.Application.AppData.Contexts.Adverts.Repositories;
using Board.Contracts.Advert;
using Board.Domain.Adverts;

namespace Board.Application.AppData.Contexts.Adverts.Services;

/// <inheritdoc />
public class AdvertService : IAdvertService
{
    private readonly IAdvertRepository _advertRepository;
    private readonly IMapper _mapper;

    public AdvertService(IAdvertRepository advertRepository, IMapper mapper)
    {
        _advertRepository = advertRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public Task<AdvertShortInfoDto[]> GetAll(CancellationToken cancellationToken)
    {
        return _advertRepository.GetAll(cancellationToken);
    }

    /// <inheritdoc />
    public Task<AdvertInfoDto> Get(Guid id, CancellationToken cancellationToken)
    {
        return _advertRepository.Get(id, cancellationToken);
    }

    /// <inheritdoc />
    public Task<AdvertInfoDto> Add(CreateAdvertDto dto, CancellationToken cancellationToken)
    {
        Advert entity = _mapper.Map<Advert>(dto);
        return _advertRepository.Add(entity, cancellationToken);
    }

    /// <inheritdoc />
    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        await _advertRepository.Delete(id, cancellationToken);
    }
}