using Board.Contracts.Account;
using Board.Domain.Account;

namespace Board.Application.AppData.Contexts.Adverts.Services;

/// <summary>
/// Сервис для регистриции\авторизации пользователя.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="possword">Пароль.</param>
    /// <param name="cancellation">Токен отмены.</param>
    /// <returns>Идентификатор пользователя.</returns>
    Task<Guid> RegisterAccountAsync(CreateAccountDto accountDto, CancellationToken cancellation);

    /// <summary>
    /// Авторизация пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="possword">Пароль.</param>
    /// <param name="cancellation">Токен отмены.</param>
    /// <returns>Токен.</returns>
    Task<string> LoginAsync(LoginAccountDto accountDto, CancellationToken cancellation);

    /// <summary>
    /// Получение текущего пользователя.
    /// </summary>
    /// <param name="cancellation">Токен отмены.</param>
    /// <returns>Текущий пользователь.</returns>
    Task<AccountDto> GetCurrentAsync(CancellationToken cancellation);
}