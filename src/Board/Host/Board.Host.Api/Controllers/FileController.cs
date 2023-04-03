using Board.Contracts;
using Board.Contracts.File;
using Microsoft.AspNetCore.Mvc;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с файлами.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class FileController : ControllerBase
{
    private readonly ILogger<FileController> _logger;

    /// <summary>
    /// Инициализирует экземпляр <see cref="FileController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    public FileController(ILogger<FileController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Получение информации о файле по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Файл с указанным идентификатором не найден.</response>
    /// <returns>Информация о файле.</returns>
    [HttpGet("{id}/info")]
    [ProducesResponseType(typeof(FileInfoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInfoById(string id, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Ok(new FileInfoDto()));
    }

    /// <summary>
    /// Загрузка файла в систему.
    /// </summary>
    /// <param name="file">Файл.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Файл успешно загружен.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = long.MaxValue)]
    [DisableRequestSizeLimit]
    public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
    {
        return await Task.Run(() => CreatedAtAction(nameof(Download), new { string.Empty }), cancellationToken);
    }


    /// <summary>
    /// Скачивание файла по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Файл с указанным идентификатором не найден.</response>
    /// <returns>Файл в виде потока.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Download(string id, CancellationToken cancellationToken)
    {
        return await Task.FromResult(File(new MemoryStream(), string.Empty, string.Empty));
    }


    /// <summary>
    /// Удаление файла по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Файл с указанным идентификатором не найден.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        return await Task.FromResult(NoContent());
    }
}