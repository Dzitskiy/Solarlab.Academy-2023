using AutoMapper;
using Board.Contracts.Category;
using Board.Domain.Categories;

namespace Board.Infrastucture.MapProfiles
{
    /// <summary>
    /// Профиль маппера для Category.
    /// </summary>
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>()
                .ForMember(s => s.Created, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.Adverts, map => map.Ignore());

            CreateMap<Category, CategoryInfoDto>()
                .ForMember(s => s.CreatedAt, map => map.MapFrom(s => s.Created));
        }
    }
}
