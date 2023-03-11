using System.ComponentModel.DataAnnotations;
using Board.Contracts.Attributes;

namespace Board.Contracts.Posts;

/// <summary>
/// Модель создания объявления.
/// </summary>
public class CreatePostDto
{
    /// <summary>
    /// Наименование.
    /// </summary>
    [Required(ErrorMessage = "Наименование не указано")]
    [StringLength(32, ErrorMessage = "Наименование либо слишком короткое, либо слишком длинное", MinimumLength = 3)]
    [ForbiddenWordsValidation]
    public string Name { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    [StringLength(100, ErrorMessage = "Описание либо слишком короткое, либо слишком длинное", MinimumLength = 10)]
    [ForbiddenWordsValidation]
    public string Description { get; set; }
    
    [MinLength(1, ErrorMessage = "Объявление должно иметь хотя бы 1 тэг")]
    [MaxLength(10, ErrorMessage = "Объявление содержит слишком много тегов")]
    public int[] Tags { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    [ActualDateTimeValidation(false, "2000-01-01")]
    public DateTime CreationDate { get; set; }
}