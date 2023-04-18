using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Contexts.Categories.Repositories;
using Board.Contracts.Category;
using Board.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.Category.Repository
{
    /// <inheritdoc cref="ICategoryRepository"/>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Domain.Categories.Category> _repository;
        private readonly IMapper _mapper;

        public CategoryRepository(IRepository<Domain.Categories.Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddAsync(Domain.Categories.Category model, CancellationToken cancellationToken)
        {
            model.Created = DateTime.UtcNow;
            await _repository.AddAsync(model, cancellationToken);
            return model.Id;
        }

        /// <inheritdoc/>
        public Task<CategoryInfoDto[]> GetActiveAsync(CancellationToken cancellationToken)
        {
            return _repository.GetAll().AsNoTracking()
                .Where(x => x.IsActive)
                .ProjectTo<CategoryInfoDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<CategoryInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(s => s.Id == id)
                              .ProjectTo<CategoryInfoDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
