using System.Security.Claims;

namespace Board.Contracts.Account
{
    /// <summary>
    /// Информация об аккаунте.
    /// </summary>
    public class AccountDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }
        
        /// <summary>
        /// Электронный адрес.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Признак блокировки.
        /// </summary>
        public bool IsBlocked { get; set; }


        public bool IsAuthenticated { get; set; }
        public string Scheme { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();

    }
}