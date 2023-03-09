using Board.Contracts.Posts;

namespace Board.Application.AppData.Contexts.Posts.Services;

/// <inheritdoc />
public class PostService : IPostService
{
    /// <inheritdoc />
    public async Task<CreatePostDto> AddPost(CreatePostDto dto, CancellationToken cancellation)
    {
        if (IsValid(dto))
        {
            // Вызов репозитория для сохранения в БД.
            
            // возврат результата.
            return await Task.Run(()=>dto, cancellation);
        }

        return new CreatePostDto();
    }

    private bool IsValid(CreatePostDto dto)
    {
        // логика валидации...
        
        return true;
    }
}