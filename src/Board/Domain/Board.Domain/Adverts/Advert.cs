using Board.Domain.Categories;

namespace Board.Domain.Adverts;

/// <summary>
/// Объявление.
/// </summary>
public class Advert
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
    /// Описание.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Признак актуальности.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Дата/время создания (UTC).
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Категория.
    /// </summary>
    public virtual Category Category { get; set; }
}