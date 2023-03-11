using System.ComponentModel.DataAnnotations;

namespace Board.Contracts.Attributes
{
    /// <summary>
    /// Атрибут проверки даты/времени на актуальность.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ActualDateTimeValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Инициализация экземляра <see cref="ActualDateTimeValidationAttribute"/>.
        /// </summary>
        /// <param name="canBeGreaterThanToday">Может ли значение быть больше, чем сегодня.</param>
        /// <param name="minimalDatetime">Минимальное значение.</param>
        public ActualDateTimeValidationAttribute(bool canBeGreaterThanToday, string minimalDatetime)
        {
            CanBeGreaterThanToday = canBeGreaterThanToday;
            Minimal = DateTime.Parse(minimalDatetime);
        }

        /// <summary>
        /// Инициализация экземляра <see cref="ActualDateTimeValidationAttribute"/>.
        /// </summary>
        /// <param name="canBeGreaterThanToday">Может ли значение быть больше, чем сегодня.</param>
        public ActualDateTimeValidationAttribute(bool canBeGreaterThanToday)
        {
            CanBeGreaterThanToday = canBeGreaterThanToday;
        }

        /// <summary>
        /// Может ли значение быть больше, чем сегодня.
        /// </summary>
        public bool CanBeGreaterThanToday { get; }

        /// <summary>
        /// Минимальное значение.
        /// </summary>
        public DateTime Minimal { get; } = DateTime.MinValue;

        /// <inheritdoc />
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dt = value as DateTime?;

            if (dt == null)
            {
                return ValidationResult.Success;
            }

            if (dt.Value < Minimal)
            {
                return new ValidationResult($"Значение не может быть меньше, чем {Minimal}");
            }

            var today = DateTime.Now.Date;
            if (!CanBeGreaterThanToday && dt.Value.Date > today)
            {
                return new ValidationResult($"Значение не может быть больше, чем {today}");
            }

            return ValidationResult.Success;
        }
    }
}