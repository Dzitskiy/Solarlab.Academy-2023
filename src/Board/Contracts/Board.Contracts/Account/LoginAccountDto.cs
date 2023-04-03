namespace Board.Contracts.Account
{
    /// <summary>
    /// Модель для входа в аккаунт.
    /// </summary>
    public class LoginAccountDto
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
    }
}