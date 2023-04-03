namespace Board.Contracts.Advert
{
    /// <summary>
    /// Краткая информация об объявлении.
    /// </summary>
    public class AdvertShortInfoDto
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