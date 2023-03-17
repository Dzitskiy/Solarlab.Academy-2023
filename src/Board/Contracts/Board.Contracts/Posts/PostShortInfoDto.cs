namespace Board.Contracts.Posts
{
    /// <summary>
    /// Краткая информация об объявлении.
    /// </summary>
    public class PostShortInfoDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Признак актуальности.
        /// </summary>
        public bool IsActive { get; set; }
    }
}