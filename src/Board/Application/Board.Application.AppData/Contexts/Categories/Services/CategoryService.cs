using AutoMapper;
using Board.Application.AppData.Contexts.Categories.Repositories;
using Board.Contracts.Category;
using Board.Domain.Categories;
using Microsoft.Extensions.Caching.Memory;

namespace Board.Application.AppData.Contexts.Categories.Services
{
    /// <inheritdoc cref="ICategoryService"/>
    public class CategoryService : ICategoryService
    {
        public const string ActiveCategoriesCachingKey = "ActiveCategories";

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        /// <inheritdoc/>
        public Task<Guid> CreateAsync(CreateCategoryDto model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateCategoryDto, Category>(model);
            return _categoryRepository.AddAsync(entity, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<CategoryInfoDto[]> GetActiveAsync(CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(ActiveCategoriesCachingKey, out CategoryInfoDto[] result))
            {
                return result;
            }

            result = await _categoryRepository.GetActiveAsync(cancellationToken);

            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };
            _memoryCache.Set(ActiveCategoriesCachingKey, result, options);

            return result;
        }

        /// <inheritdoc/>
        public Task<CategoryInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _categoryRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
