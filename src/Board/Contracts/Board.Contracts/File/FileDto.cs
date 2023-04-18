namespace Board.Contracts.File
{
    /// <summary>
    /// Модель файла.
    /// </summary>
    public class FileDto
    {
        /// <summary>
        /// Имя файла.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Контент файла.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// ContentType файла.
        /// </summary>
        public string ContentType { get; set; }
    }
}
