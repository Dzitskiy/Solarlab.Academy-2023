using Board.Contracts.Interfaces;

namespace Board.Application.AppData.Services
{
    /// <summary>
    /// Реализация <see cref="IForbiddenWordsService"/>
    /// </summary>
    public class ForbiddenWordsService : IForbiddenWordsService
    {
        /// <inheritdoc />
        public string[] GetForbiddenWords()
        {
            return new[] { "дурак", "реклама", "взятка" };
        }
    }
}