namespace Board.Domain.Account
{
    /// <summary>
    /// Акаунт
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login { get; set; }
        
        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Дата регистрации.
        /// </summary>
        public DateTime Created { get; set; }
    }
}