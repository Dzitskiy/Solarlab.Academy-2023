using Board.Application.AppData.Contexts.Posts.Repositories;
using Board.Contracts.Posts;
using Board.Domain.Posts;
using Board.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.Posts.Repository;

public class PostRepository : IPostRepository
{
    private readonly IRepository<Post> _postRepository;

    public PostRepository(IRepository<Post> postRepository)
    {
        _postRepository = postRepository;
    }

    /// <summary>
    /// TODO: Подлежит рефактору. Не использовать!
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<CreatePostDto> AddPost(Post entity)
    {
        var result = _postRepository.AddAsync(entity);
        return Task.Run(() => new CreatePostDto());
    }
}