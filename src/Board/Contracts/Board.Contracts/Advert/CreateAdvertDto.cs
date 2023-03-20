using System.ComponentModel.DataAnnotations;
using Board.Contracts.Attributes;

namespace Board.Contracts.Advert;

/// <summary>
/// Модель создания объявления.
/// </summary>
public class CreateAdvertDto
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

    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Теги.
    /// </summary>
    [MaxLength(10, ErrorMessage = "Объявление содержит слишком много тегов")]
    public string[] Tags { get; set; }
}