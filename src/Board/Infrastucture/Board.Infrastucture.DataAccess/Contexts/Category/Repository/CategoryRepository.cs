using Board.Application.AppData.Contexts.Categories.Repositories;
using Board.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.Category.Repository
{
    /// <inheritdoc cref="ICategoryRepository"/>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Domain.Categories.Category> _repository;

        public CategoryRepository(IRepository<Domain.Categories.Category> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddAsync(Domain.Categories.Category model, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(model, cancellationToken);
            return model.Id;
        }

        /// <inheritdoc/>
        public Task<List<Domain.Categories.Category>> GetActiveAsync(CancellationToken cancellationToken)
        {
            return  _repository.GetAll().Where(s => s.IsActive).ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<Domain.Categories.Category> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetByIdAsync(id, cancellationToken);
        }
    }
}
