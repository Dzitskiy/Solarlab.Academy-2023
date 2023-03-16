using Board.Contracts.Posts;

namespace Board.Application.AppData.Contexts.Posts.Services;

/// <summary>
/// Сервис для работы с объявлениями.
/// </summary>
public interface IPostService
{
    /// <summary>
    /// Создает объявление.
    /// </summary>
    /// <param name="dto">Модель создания объявления.</param>
    /// <param name="cancellation">Токен отмены операции.</param>
    /// <returns>Модель объявления.</returns>
    Task<PostInfoDto> AddPost(CreatePostDto dto, CancellationToken cancellation);
}