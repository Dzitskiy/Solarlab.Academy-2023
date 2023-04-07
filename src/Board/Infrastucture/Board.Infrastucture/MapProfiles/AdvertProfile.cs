using AutoMapper;
using Board.Contracts.Advert;
using Board.Domain.Adverts;

namespace Board.Infrastucture.MapProfiles
{
    /// <summary>
    /// Профиль маппера для Advert.
    /// </summary>
    public class AdvertProfile : Profile
    {
        public AdvertProfile()
        {
            CreateMap<CreateAdvertDto, Advert>(MemberList.None)
                .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
                .ForMember(d => d.CategoryId, map => map.MapFrom(s => s.CategoryId))
                .ForMember(d => d.Description, map => map.MapFrom(s => s.Description))
                .ForMember(d => d.IsActive, map => map.MapFrom(s => true))
                .ForMember(d => d.Created, map => map.MapFrom(s => DateTime.UtcNow));

            CreateMap<Advert, AdvertInfoDto>() 
                .ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
                .ForMember(d => d.CategoryId, map => map.MapFrom(s => s.CategoryId))
                .ForMember(d => d.Description, map => map.MapFrom(s => s.Description))
                .ForMember(d => d.CreatedAt, map => map.MapFrom(s => s.Created))
                .ForMember(d => d.IsActive, map => map.MapFrom(s => s.IsActive));

            CreateMap<Advert, AdvertShortInfoDto>()
                .ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
                .ForMember(d => d.IsActive, map => map.MapFrom(s => s.IsActive));
        }
    }
}
