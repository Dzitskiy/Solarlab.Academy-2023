namespace Board.Contracts
{
    /// <summary>
    /// Модель ошибки.
    /// </summary>
    public class ErrorDto
    {
        /// <summary>
        /// Наименование сервиса, в котором произошла ошибка.
        /// </summary>
        public string ServiceName { get; set; } = string.Empty;

        /// <summary>
        /// Код ошибки.
        /// </summary>
        public string ErrorCode { get; set; } = string.Empty;

        /// <summary>
        /// Сообщение для пользователя.
        /// </summary>
        public string UserMessage { get; set; } = string.Empty;

        /// <summary>
        /// Сообщение для разработчика.
        /// </summary>
        public string DeveloperMessage { get; set; } = string.Empty;

        /// <summary>
        /// Вложенные ошибки.
        /// </summary>
        public ErrorDto[] InternalErrors { get; set; }
    }
}