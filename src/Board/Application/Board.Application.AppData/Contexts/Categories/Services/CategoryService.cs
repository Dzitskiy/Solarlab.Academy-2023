using AutoMapper;
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
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Task<Guid> CreateAsync(CreateCategoryDto model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateCategoryDto, Category>(model);
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
        public Task<CategoryInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _categoryRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
