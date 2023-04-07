using Board.Contracts.Advert;

namespace Board.Application.AppData.Contexts.Adverts.Services;

/// <inheritdoc />
public class AdvertService : IAdvertService
{
    /// <inheritdoc />
    public async Task<AdvertInfoDto> AddAdvert(CreateAdvertDto dto, CancellationToken cancellation)
    {
        if (IsValid(dto))
        {
            // Вызов репозитория для сохранения в БД.
            
            // возврат результата.
            return await Task.Run(() => new AdvertInfoDto(), cancellation);
        }

        return null;
    }

    private bool IsValid(CreateAdvertDto dto)
    {
        // логика валидации...
        
        return true;
    }
}