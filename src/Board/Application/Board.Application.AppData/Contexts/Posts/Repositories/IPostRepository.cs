using Board.Contracts.Posts;
using Board.Domain.Posts;

namespace Board.Application.AppData.Contexts.Posts.Repositories;

public interface IPostRepository
{
    Task<CreatePostDto> AddPost(Post entity);
}