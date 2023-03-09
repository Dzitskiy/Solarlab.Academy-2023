namespace Board.Contracts.Posts;

/// <summary>
/// Модель создания объявления.
/// </summary>
public class CreatePostDto
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreationDate { get; set; }
}