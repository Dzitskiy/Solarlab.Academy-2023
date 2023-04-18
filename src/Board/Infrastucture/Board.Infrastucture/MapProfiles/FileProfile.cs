using AutoMapper;
using Board.Contracts.File;

namespace Board.Infrastucture.MapProfiles
{
    /// <summary>
    /// Профиль работы с файлами.
    /// </summary>
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileDto, Domain.Files.File>(MemberList.None)
                .ForMember(d => d.Length, map => map.MapFrom(s => s.Content.Length))
                .ForMember(d => d.Created, map => map.MapFrom(s => DateTime.UtcNow));

            CreateMap<Domain.Files.File, FileDto>(MemberList.None);

            CreateMap<Domain.Files.File, FileInfoDto>(MemberList.None);
        }
    }
}
