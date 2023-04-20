using AutoMapper;
using Board.Application.AppData.Contexts.Categories.Repositories;
using Board.Contracts.Category;
using Board.Domain.Categories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
//using Newtonsoft.Json;

namespace Board.Application.AppData.Contexts.Categories.Services
{
    /// <inheritdoc cref="ICategoryService"/>
    public class CategoryService : ICategoryService
    {
        public const string ActiveCategoriesCachingKey = "ActiveCategories";

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
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
            //memoryCache
            if (_memoryCache.TryGetValue(ActiveCategoriesCachingKey, out CategoryInfoDto[] result))
            {
                return result;
            }
            //distributedCache
            string serializedString = await _distributedCache.GetStringAsync(ActiveCategoriesCachingKey);
            if (serializedString != null)
            {
                return JsonSerializer.Deserialize<CategoryInfoDto[]>(serializedString);
            }

            result = await _categoryRepository.GetActiveAsync(cancellationToken);

            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };
            _memoryCache.Set(ActiveCategoriesCachingKey, result, options);

            await _distributedCache.SetStringAsync(
                                key: ActiveCategoriesCachingKey,
                                value: JsonSerializer.Serialize(result),
                                options: new DistributedCacheEntryOptions
                                {
                                    SlidingExpiration =  TimeSpan.FromSeconds(30),
                                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(1)
                                });

            return result;
        }

        /// <inheritdoc/>
        public Task<CategoryInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _categoryRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
