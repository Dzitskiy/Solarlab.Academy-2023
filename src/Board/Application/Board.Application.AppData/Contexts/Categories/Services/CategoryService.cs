using Board.Application.AppData.Contexts.Categories.Repositories;
using Board.Contracts.Category;
using Board.Domain.Categories;
using System.Xml.Linq;

namespace Board.Application.AppData.Contexts.Categories.Services
{
    /// <inheritdoc cref="ICategoryService"/>
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <inheritdoc/>
        public Task<Guid> CreateAsync(CreateCategoryDto model, CancellationToken cancellationToken)
        {
            var entity = new Category
            {
                Name = model.Name,
                ParentId= model.ParentId,
                IsActive= model.IsActive,
                Created = DateTime.UtcNow
            };

            return _categoryRepository.AddAsync(entity, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<List<CategoryInfoDto>> GetActiveAsync(CancellationToken cancellationToken)
        {
            var entities = await _categoryRepository.GetActiveAsync(cancellationToken);
            var result = entities.Select(s => new CategoryInfoDto
            {
                Name = s.Name,
                ParentId = s.ParentId,
                IsActive = s.IsActive,
                CreatedAt = s.Created,
                Id = s.Id,
            });
            return result.ToList();
        }

        /// <inheritdoc/>
        public async Task<CategoryInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _categoryRepository.GetByIdAsync(id, cancellationToken);
            var result = new CategoryInfoDto
            {
                Id= entity.Id,
                Name= entity.Name,
                ParentId= entity.ParentId,
                IsActive= entity.IsActive,
                CreatedAt = entity.Created
            };
            return result;
        }
    }
}
