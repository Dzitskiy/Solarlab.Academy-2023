using System.ComponentModel.DataAnnotations;
using Board.Contracts.Interfaces;

namespace Board.Contracts.Attributes
{
    /// <summary>
    /// Атрибут проверки строкового поля на содержание запрещённых слов.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ForbiddenWordsValidationAttribute : ValidationAttribute
    {
        /// <inheritdoc />
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var valueAsString = value as string;

            if (valueAsString == null)
            {
                return ValidationResult.Success;
            }

            // получить сервис из контекста
            var service = (IForbiddenWordsService?)validationContext.GetService(typeof(IForbiddenWordsService));

            if (service == null)
            {
                return ValidationResult.Success;
            }

            // получить список запрещённых слов из сервиса
            var forbiddenWords = service.GetForbiddenWords();

            // определить - содержит ли значение хотя бы одно запрещённое слово (при проверке регистр не учитывать)
            var valueContainsAnyForbiddenWord = forbiddenWords.Any(forbiddenWord =>
                valueAsString.Contains(forbiddenWord, StringComparison.InvariantCultureIgnoreCase));

            return valueContainsAnyForbiddenWord
                ? new ValidationResult("Значение содержит запрещённые слова")
                : ValidationResult.Success;
        }
    }
}