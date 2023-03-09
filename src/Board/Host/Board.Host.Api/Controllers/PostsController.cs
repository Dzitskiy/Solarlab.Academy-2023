using System.Text.Json.Serialization;
using Board.Application.AppData.Contexts.Posts.Services;
using Board.Contracts.Posts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с объявлениями.
/// </summary>
[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly ILogger<PostsController> _logger;
    private readonly IPostService _postService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="PostsController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="postService">Сервис для работы с объявлениями.</param>
    public PostsController(ILogger<PostsController> logger, IPostService postService)
    {
        _logger = logger;
        _postService = postService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-posts")]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation($"Запрос объявлений");

        return await Task.Run(Ok);
    }

    /// <summary>
    /// Сохраняет новое объявление.
    /// </summary>
    /// <param name="dto">Модель создания объявления.</param>
    /// <param name="cancellation">Отмена оперрации.</param>
    /// <returns>Модель созданного объявления.</returns>
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto, CancellationToken cancellation)
    {
        _logger.LogInformation($"{JsonConvert.SerializeObject(dto)}");

        var result = await _postService.AddPost(dto, cancellation);
        
        return await Task.Run(() => Created(string.Empty, result));
    }
}