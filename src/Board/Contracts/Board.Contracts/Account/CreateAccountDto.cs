using System.ComponentModel.DataAnnotations;
using Board.Contracts.Attributes;

namespace Board.Contracts.Account
{
    /// <summary>
    /// Модель для создания аккаунта.
    /// </summary>
    public class CreateAccountDto
    {
        /// <summary>
        /// Логин.
        /// </summary>
        [Required(ErrorMessage = "Логин не указан")]
        [StringLength(64, ErrorMessage = "Логин либо слишком короткий, либо слишком длинный", MinimumLength = 3)]
        [ForbiddenWordsValidation]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required(ErrorMessage = "Пароль не указан")]
        [StringLength(32, MinimumLength = 8)]
        public string Password { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(ErrorMessage = "Фамилия не указана")]
        [StringLength(32, MinimumLength = 2)]
        [ForbiddenWordsValidation]
        public string LastName { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Required(ErrorMessage = "Имя не указано")]
        [StringLength(32, MinimumLength = 2)]
        [ForbiddenWordsValidation]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [Required(ErrorMessage = "Отчество не указано")]
        [StringLength(32, MinimumLength = 2)]
        [ForbiddenWordsValidation]
        public string MiddleName { get; set; }

        /// <summary>
        /// Электронный адрес.
        /// </summary>
        [Required(ErrorMessage = "Электронный адрес не указан")]
        [RegularExpression(@"^.+\@.+\..+$")]
        public string Email { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime? Birthday { get; set; }
    }
}