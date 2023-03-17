using Board.Contracts;
using Board.Contracts.Category;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с категориями.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;

    /// <summary>
    /// Инициализирует экземпляр <see cref="CategoryController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Получить список категорий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей категорий.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryShortInfoDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрос категорий");

        return await Task.Run(() => Ok(Enumerable.Empty<CategoryShortInfoDto>()), cancellationToken);
    }

    /// <summary>
    /// Получить категорию по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Категория с указанным идентификатором не найдена.</response>
    /// <returns>Модель категории.</returns>
    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(CategoryInfoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await Task.Run(() => Ok(new CategoryInfoDto()), cancellationToken);
    }

    /// <summary>
    /// Создать новую категорию.
    /// </summary>
    /// <param name="dto">Модель создания категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Категория успешно создана.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель созданной категории.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryInfoDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto, CancellationToken cancellationToken)
    {
        return await Task.Run(() => CreatedAtAction(nameof(GetById), new { Guid.Empty }), cancellationToken);
    }

    /// <summary>
    /// Обновить категорию.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Объявление с указанным идентификатором не найдено.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновлённой категории.</returns>
    [HttpPut("{id:Guid}")]
    [ProducesResponseType(typeof(CategoryInfoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDto dto, CancellationToken cancellationToken)
    {
        return await Task.Run(() => Ok(new CategoryInfoDto()), cancellationToken);
    }

    /// <summary>
    /// Частично обновить категорию.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Объявление с указанным идентификатором не найдено.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновлённой категории.</returns>
    [HttpPatch("{id:Guid}")]
    [ProducesResponseType(typeof(CategoryInfoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<UpdateCategoryDto> dto,
        CancellationToken cancellationToken)
    {
        return await Task.Run(() => Ok(new CategoryInfoDto()), cancellationToken);
    }

    /// <summary>
    /// Удалить категорию по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="204">Запрос выполнен успешно.</response>
    /// <response code="403">Доступ запрещён.</response>
    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        return await Task.Run(NoContent, cancellationToken);
    }
}